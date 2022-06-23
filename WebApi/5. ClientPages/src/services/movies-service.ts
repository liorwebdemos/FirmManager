import { autoinject } from "aurelia-framework";
import { HttpClient } from "aurelia-fetch-client";
import environment from "../../config/environment.json";
import { MovieModel } from "models";
import { plainToInstance } from "class-transformer";

@autoinject()
export class MoviesService
{
  constructor(private httpClient: HttpClient)
  {
    httpClient.configure(config =>
    {
      config
        .useStandardConfiguration()
        .withBaseUrl(environment.apiBaseUrl);
    });
  }

  // @cache() -> do client cache
  public getPopularMovies(): Promise<MovieModel[]>
  {
    return this.httpClient.get("movies/popular")
      .then(response => response.json())
      .then((response: MovieModel[]) => plainToInstance(MovieModel, response));
  }

  // @cache() -> do client cache
  public getMoviesByKeyword(keyword: string): Promise<MovieModel[]>
  {
    return this.httpClient.get(`movies?keyword=${ keyword }`) // better yet: this.advancedHttpClient.queryString("movies", { keyword }) which auto-formats any querystring
      .then(response => response.json())
      .then((response: MovieModel[]) => plainToInstance(MovieModel, response));
  }
}
