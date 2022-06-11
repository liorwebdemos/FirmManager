using PopDb.Models;
using WebApi.BL.Contracts;
using WebApi.DAL.Contracts;

namespace WebApi.BL.Implementation
{
    public class BLMovies : IBLMovies
    {
        private readonly IMoviesService MoviesService;

        public BLMovies(IMoviesService moviesService)
        {
            MoviesService = moviesService;
        }

        public async Task<IEnumerable<Movie>?> GetPopularMovies()
        {
            var movies = await MoviesService.GetPopularMovies();
            return movies?.OrderByDescending(m => m.Year);
        }
    }
}
