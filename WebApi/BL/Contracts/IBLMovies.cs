using PopDb.Models;

namespace WebApi.BL.Contracts
{
    public interface IBLMovies
    {
        Task<IEnumerable<Movie>?> GetPopularMovies();
    }
}
