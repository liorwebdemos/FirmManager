import { PLATFORM } from "aurelia-pal";
import { Router, RouterConfiguration } from "aurelia-router";
import "assets/fonts/heebo-v10-latin_hebrew/index.scss"; // importing here and not on app.scss due to webpack url resolution issue on css files (TODO: add a proper link/reference for full info)

export class App
{
  public router: Router;

  public configureRouter(config: RouterConfiguration, router: Router): void
  {
    config.title = "FirmManager";
    config.map([
      {
        route: "",
        name: "departments-list",
        moduleId: PLATFORM.moduleName("./components/departments-list/departments-list"),
        nav: true,
        title: "Departments List"
      }
      // {
      //   route: "workers",
      //   name: "workers-list",
      //   moduleId: PLATFORM.moduleName("./components/workers-list/workers-list"),
      //   nav: true,
      //   title: "Workers List"
      // }
    ]);

    this.router = router;
  }
}
