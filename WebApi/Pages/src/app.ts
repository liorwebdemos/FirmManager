import {PLATFORM} from 'aurelia-pal';
import {Router, RouterConfiguration} from 'aurelia-router';

export class App {
  public router: Router;

  // Note: a router is obviously redundant in this simple, simple app. it's just here for demonstration sake.
  public configureRouter(config: RouterConfiguration, router: Router): void {
    config.title = 'Aurelia';
    config.map([
      {
        route: '',
        name: 'popular-movies',
        moduleId: PLATFORM.moduleName('./components/popular-movies/popular-movies'),
        nav: true,
        title: 'Popular Movies'
      }
    ]);

    this.router = router;
  }
}
