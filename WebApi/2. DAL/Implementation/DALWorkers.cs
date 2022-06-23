using Microsoft.EntityFrameworkCore;
using PopDb.Models;
using WebApi.DAL.Contexts;
using WebApi.DAL.Contracts;

namespace WebApi.DAL.Implementation
{
    public class DALWorkers : IDALWorkers
    {
        private readonly ILogger<DALWorkers> _logger;
        private readonly MainContext _mainContext;

        public DALWorkers(
            //IConfiguration configuration,
            ILogger<DALWorkers> logger,
            MainContext mainContext
        )
        {
            _logger = logger;
            _mainContext = mainContext;
        }

        public WorkerModel? GetById(int workerId)
        {
            return _mainContext.Workers.FirstOrDefault(w => w.Id == workerId);
        }

        public IQueryable<WorkerModel> GetAll()
        {
            return _mainContext.Workers.AsNoTracking(); // tracking is expensive
        }
    }
}
