import { autoinject } from "aurelia-framework";
import { HttpClient } from "aurelia-fetch-client";
import environment from "../../config/environment.json"; // TODO: prod/not?

@autoinject()
export class MoviesService
{
  constructor(private httpClient: HttpClient)
  {
    httpClient.configure(config =>
    {
      config
        .useStandardConfiguration()
        .withBaseUrl(environment.apiBaseUrl); // TODO
    });
  }

  public getPopularMovies(): Promise<void>
  {
    return this.httpClient.get("/movies/popular")
      .then(response => response.json());
  }
}
