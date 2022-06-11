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
        private IBLMovies _blMovies;

        public MoviesController(IBLMovies BLMovies) 
        {
            _blMovies = BLMovies;
        }

        [HttpGet("popular")]
        public Task<IEnumerable<Movie>?> GetPopularMovies()
        {
            return _blMovies.GetPopularMovies();
        }
    }
}