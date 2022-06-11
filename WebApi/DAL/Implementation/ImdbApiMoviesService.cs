using PopDb.Models;
using WebApi.DAL.Contracts;
using WebApi.DAL.Helpers;

namespace WebApi.DAL.Implementation
{
    public class MoviesList
    {
        public Movie[]? items { get; set; }
        public string? ErrorMessage { get; set; }
    }

    public class ImdbApiMoviesService : IMoviesService
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiKey;
        private readonly ILogger<ImdbApiMoviesService> _logger;

        public HttpClient HttpClient => _httpClient;
        public string ApiKey => _apiKey;

        public ImdbApiMoviesService(
            HttpClient httpClient,
            IConfiguration configuration,
            ILogger<ImdbApiMoviesService> logger
        )
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri(configuration[$"BaseUrls:{nameof(ImdbApiMoviesService)}"]);
            _httpClient.DefaultRequestHeaders.Add("Accept", "application/json");

            _apiKey = configuration[$"ApiKeys:{nameof(ImdbApiMoviesService)}"];

            _logger = logger;
        }

        public async Task<IEnumerable<Movie>?> GetPopularMovies()
        {
            var httpResponse = await _httpClient.GetAsync($"MostPopularMovies/{ApiKey}");
            httpResponse.EnsureSuccessStatusCode();

            var moviesList = await httpResponse.Content.ReadFromJsonAsync<MoviesList>(JsonHelper.CustomJsonSerializerOptions);
            //-- OR via the custom extension method we created for string: --
            //var moviesListString = await httpResponse.Content.ReadAsStringAsync();
            //var moviesList = moviesListString.JsonDeserialize<MoviesList>();
            return moviesList?.items;
        }
    }
}
