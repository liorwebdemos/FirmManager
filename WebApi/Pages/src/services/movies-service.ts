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

  // @cache()
  public getPopularMovies(): Promise<MovieModel[]>
  {
    return this.httpClient.get("movies/popular")
      .then(response => response.json())
      .then((response: MovieModel[]) => plainToInstance(MovieModel, response)); // not actually needed here, since we don't have properties with date type on the movie model. it is ultimately needed, though, in almost every serious project :)
  }
}
