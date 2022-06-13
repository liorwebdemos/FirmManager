import { PLATFORM } from "aurelia-pal";
import { Router, RouterConfiguration } from "aurelia-router";
import "assets/fonts/heebo-v10-latin_hebrew/index.scss"; // importing here and not on app.scss due to webpack url resolution issue on css files (TODO: add a proper link/reference for full info)

export class App
{
  public router: Router;

  // Note: a router is obviously redundant in this simple, simple app. it's just here for demonstration sake.
  public configureRouter(config: RouterConfiguration, router: Router): void
  {
    config.title = "PopDb";
    config.map([
      {
        route: "",
        name: "popular-movies",
        moduleId: PLATFORM.moduleName("./components/popular-movies/popular-movies"),
        nav: true,
        title: "Popular Movies"
      }
    ]);

    this.router = router;
  }
}
