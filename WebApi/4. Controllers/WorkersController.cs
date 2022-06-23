using Microsoft.AspNetCore.Mvc;
using WebApi.BL.Contracts;
using WebApi.Models;

namespace WebApi.Controllers
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
        public IEnumerable<WorkerModel> GetWorkers()
        {
            return _blMovies.GetWorkers();
        }

        [HttpGet("{workerId}")]
        public WorkerModel? GetWorkerById(int workerId)
        {
            return _blMovies.GetWorkerById(workerId);
        }

        [HttpPost("")]
        public WorkerModel AddWorker([FromBody] WorkerModel worker)
        {
            return _blMovies.AddWorker(worker);
        }

        [HttpPut("")] // there's also REST convention of {workerId}
        public WorkerModel UpdateWorker([FromBody] WorkerModel worker)
        {
            return _blMovies.UpdateWorker(worker);
        }

        [HttpDelete("")]
        public WorkerModel DeleteWorker(int workerId)
        {
            return _blMovies.DeleteWorker(workerId);
        }
    }
}