import { autoinject, computedFrom, bindable, bindingMode } from "aurelia-framework";
import { MovieModel } from "models";
import { DialogService } from "aurelia-dialog";
import { MovieDetailsModal } from "components/movie-details-modal/movie-details-modal";

@autoinject()
export class MoviesList
{
  @bindable({ defaultBindingMode: bindingMode.toView }) private movies: MovieModel[];
  @bindable({ defaultBindingMode: bindingMode.toView }) private numOfMoviesPerPage = 10;
  private pageNumber = 1;

  constructor(
    private dialogService: DialogService
  ) { }

  private openMovieDetailsModal(movie: MovieModel): void
  {
    this.dialogService.open({
      viewModel: MovieDetailsModal,
      model: movie
    });
  }

  //#region pagination
  // note: this is some low level code that we probably wouldn't put in this class this way
  // also, it'd probably be better to involve the router and page url (browser history api) when the page changes
  @computedFrom("movies")
  get totalNumOfPages()
  {
    if (!this.movies?.length) return;

    return Math.ceil(this.movies.length / this.numOfMoviesPerPage);
  }

  @computedFrom("movies", "pageNumber")
  get currentPageMovies(): MovieModel[]
  {
    if (!this.movies?.length) return;

    const lastMovieIndex = this.movies.length - 1;
    const pageStartIndex = this.numOfMoviesPerPage * (this.pageNumber - 1);
    if (pageStartIndex > lastMovieIndex) return;
    const possiblyPageEndIndex = this.numOfMoviesPerPage * this.pageNumber - 1;
    const pageEndIndex = possiblyPageEndIndex > lastMovieIndex
      ? lastMovieIndex
      : possiblyPageEndIndex;

    return this.movies.slice(pageStartIndex, pageEndIndex + 1);
  }
  @computedFrom("currentPageMovies")
  private get hasPreviousPage(): boolean
  {
    if (!this.currentPageMovies?.length) return;

    const firstMovieInPage = this.currentPageMovies[0];
    const firstMovieOverall = this.movies[0];
    return firstMovieInPage.id !== firstMovieOverall.id;
  }
  @computedFrom("currentPageMovies")
  private get hasNextPage(): boolean
  {
    if (!this.currentPageMovies?.length) return;

    const lastMovieInPage = this.currentPageMovies[this.currentPageMovies.length - 1];
    const lastMovieOverall = this.movies[this.movies.length - 1];
    return lastMovieInPage.id !== lastMovieOverall.id;
  }
  //#endregion pagination
}
