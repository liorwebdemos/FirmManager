using PopDb.Models;
using WebApi.DAL.Contracts;
using WebApi.DAL.Helpers;

// see: https://imdb-api.com/api
namespace WebApi.DAL.Implementation
{
    public class MostPopularData
    {
        public List<MovieModel>? Items { get; set; }
        public string? ErrorMessage { get; set; }
    }
    public class SearchData
    {
        public string? SearchType { get; set; }
        public string? Expression { get; set; }
        public List<SearchResult>? Results { get; set; }
        public string? ErrorMessage { get; set; }
    }
    public class SearchResult
    {
        public string? Id { get; set; }
        public string? ResultType { get; set; }
        public string? Image { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
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

        public async Task<IEnumerable<MovieModel>?> GetPopularMovies()
        {
            var httpResponse = await _httpClient.GetAsync($"MostPopularMovies/{ApiKey}");
            httpResponse.EnsureSuccessStatusCode();

            var mostPopularData = await httpResponse.Content.ReadFromJsonAsync<MostPopularData>(JsonHelper.CustomJsonSerializerOptions);
            //FYI, can also deserialize via the custom extension method we created for type string:
            // var mostPopularDataString = await httpResponse.Content.ReadAsStringAsync();
            // var mostPopularData = mostPopularDataString.JsonDeserialize<MostPopularData>();
            return mostPopularData?.Items;
        }

        public async Task<IEnumerable<MovieModel>?> GetMoviesByKeyword(string keyword)
        {
            var httpResponse = await _httpClient.GetAsync($"SearchMovie/{ApiKey}/{keyword}");
            httpResponse.EnsureSuccessStatusCode();

            var searchData = await httpResponse.Content.ReadFromJsonAsync<SearchData>(JsonHelper.CustomJsonSerializerOptions);
            //In serious projects, we'll probably use a nuget (like Mapster) to do mappings.

            return searchData?.Results?.Select(r => new MovieModel {
                Id = r.Id,
                Title = r.Title,
                Image = r.Image
            });
        }
    }
}
