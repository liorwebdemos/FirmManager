using Microsoft.AspNetCore.Mvc;
using PopDb.Models;
using WebApi.BL.Contracts;

namespace PopDb.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MoviesController : ControllerBase
    {
        private readonly IBLMovies _blMovies;

        public MoviesController(IBLMovies BLMovies) 
        {
            _blMovies = BLMovies;
        }

        [HttpGet("popular")]
        public Task<IEnumerable<MovieModel>?> GetPopularMovies()
        {
            return _blMovies.GetPopularMovies();
        }
    }
}