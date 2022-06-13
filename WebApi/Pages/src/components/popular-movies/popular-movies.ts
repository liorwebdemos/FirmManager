import { autoinject } from "aurelia-framework";
import { MoviesService } from "services";
import { MovieModel } from "models";
import { DialogService } from "aurelia-dialog";

@autoinject()
export class PopularMovies
{
  private movies: MovieModel[];

  constructor(
    private moviesService: MoviesService,
    private dialogService: DialogService
  ) { }

  private activate(): void
  {
    this.getMovies();
  }

  // @handleErrors() -> catch errors and notify the end user
  // @busyTracking() -> add a loading indicator
  private getMovies(): Promise<MovieModel[]>
  {
    return this.moviesService.getPopularMovies()
      .then(movies => this.movies = movies);
  }

  // private openMovieDetailsModal(movie: MovieModel): void
  // {
  //   this.dialogService.open({
  //     viewModel: MovieDetailsModal,
  //     model: movie
  //   });
  // }
}
