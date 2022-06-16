using PopDb.Models;

namespace WebApi.DAL.Contracts
{
    public interface IMoviesService
    {
        HttpClient HttpClient { get; }
        string ApiKey { get; }
        Task<IEnumerable<MovieModel>?> GetPopularMovies();
        Task<IEnumerable<MovieModel>?> GetMoviesByKeyword(string keyword);
    }
}
