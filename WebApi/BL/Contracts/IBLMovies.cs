using PopDb.Models;

namespace WebApi.BL.Contracts
{
    public interface IBLMovies
    {
        Task<IEnumerable<MovieModel>?> GetPopularMovies();

        Task<IEnumerable<MovieModel>?> GetMoviesByKeyword(string keyword);
    }
}
