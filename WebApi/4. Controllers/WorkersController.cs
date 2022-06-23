using Microsoft.AspNetCore.Mvc;
using PopDb.Models;
using WebApi.BL.Contracts;

namespace PopDb.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WorkersController : ControllerBase
    {
        private readonly IBLWorkers _blMovies;

        public WorkersController(IBLWorkers blMovies)
        {
            _blMovies = blMovies;
        }

        [HttpGet("")]
        public IEnumerable<WorkerModel>? GetWorkers()
        {
            return _blMovies.GetWorkers();
        }

        [HttpGet("{workerId}")]
        public WorkerModel? GetWorkerById(int workerId)
        {
            return _blMovies.GetWorkerById(workerId);
        }
    }
}