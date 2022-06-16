import { autoinject, computedFrom } from "aurelia-framework";
import { MoviesService } from "services";
import { MovieModel } from "models";
import { watch } from "aurelia-watch-decorator";

@autoinject()
export class PopularMovies
{
  private popularMovies: MovieModel[];
  private moviesByKeyword: MovieModel[];
  private keyword: string;

  @computedFrom("keyword")
  get isInSearchMode(): boolean
  {
    if (!this.keyword?.length) return;
    return !!this.keyword?.trim();
  }

  constructor(
    private moviesService: MoviesService
  ) { }

  private activate(keyword?: string): void
  {
    this.keyword = keyword;
    this.getPopularMovies();
  }

  // @handleErrors() -> catch errors and notify the end user
  // @busyTracking() -> configure a loading indicator while the promise resolves
  private getPopularMovies(): Promise<MovieModel[]>
  {
    return this.moviesService.getPopularMovies()
      .then(popularMovies => this.popularMovies = popularMovies);
  }

  // @handleErrors() -> catch errors and notify the end user
  // @busyTracking() -> configure a loading indicator while the promise resolves
  @watch<PopularMovies>(t => t.keyword)
  private getMoviesByKeyword(keyword: string): Promise<MovieModel[]>
  {
    if (!this.isInSearchMode) return;
    this.moviesByKeyword = null;
    return this.moviesService.getMoviesByKeyword(keyword)
      .then(moviesByKeyword => this.moviesByKeyword = moviesByKeyword);
  }
}
