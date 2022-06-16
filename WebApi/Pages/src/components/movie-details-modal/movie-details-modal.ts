import { autoinject } from "aurelia-framework";
import { DialogController } from "aurelia-dialog";
import { MovieModel } from "models/movie-model";

@autoinject()
export class MovieDetailsModal
{
  private movie: MovieModel;

  constructor(private dialogController: DialogController) { }

  canActivate(movie: MovieModel): boolean
  {
    return !!movie;
  }

  activate(movie: MovieModel): void
  {
    this.movie = movie;
  }
}
