using Microsoft.AspNetCore.Mvc;
using PopDb.Models;
using WebApi.BL.Contracts;
using WebApi.DAL.Contracts;

namespace PopDb.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MoviesController : ControllerBase
    {
        private IBLMovies _BLMovies;
        //private readonly ILogger<MoviesController> _logger;

        public MoviesController(IBLMovies BLMovies) //ILogger<MoviesController> logger
        {
            _BLMovies = BLMovies;
        }

        [HttpGet("popular")]
        public Task<IEnumerable<Movie>?> GetPopularMovies()
        {
            return _BLMovies.GetPopularMovies();
        }
    }
}