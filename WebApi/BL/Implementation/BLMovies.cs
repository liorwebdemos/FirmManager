using PopDb.Models;
using WebApi.BL.Contracts;
using WebApi.DAL.Contracts;

namespace WebApi.BL.Implementation
{
    public class BLMovies : IBLMovies
    {
        private readonly IMoviesService MoviesService;
        private static readonly int DefaultNumberOfReturnedItems = 100;

        public BLMovies(IMoviesService moviesService)
        {
            MoviesService = moviesService;
        }

        public async Task<IEnumerable<MovieModel>?> GetPopularMovies()
        {
            var movies = await MoviesService.GetPopularMovies();
            return movies?
                .OrderByDescending(m => m.Year)
                .Take(DefaultNumberOfReturnedItems );
        }

        public async Task<IEnumerable<MovieModel>?> GetMoviesByKeyword(string keyword)
        {
            var movies = await MoviesService.GetMoviesByKeyword(keyword);
            return movies?.Take(DefaultNumberOfReturnedItems);
        }
    }
}
