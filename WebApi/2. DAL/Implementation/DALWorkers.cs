using Microsoft.EntityFrameworkCore;
using PopDb.Models;
using WebApi.DAL.Contracts;
using WebApi.DAL.Implementation.Contexts;

namespace WebApi.DAL.Implementation
{
    public class DALWorkers : IDALWorkers
    {
        private readonly ILogger<DALWorkers> _logger;
        private readonly MainContext _mainContext;

        public DALWorkers(
            ILogger<DALWorkers> logger,
            MainContext mainContext
        )
        {
            _logger = logger;
            _mainContext = mainContext;
        }

        public void SaveChanges()
        {
            _mainContext.SaveChanges();
        }

        public WorkerModel? GetById(int workerId)
        {
            return _mainContext.Workers.Find(workerId);
        }

        public IQueryable<WorkerModel> GetAll()
        {
            return _mainContext.Workers.AsNoTracking(); // tracking is expensive. if we need to, we can also create GetAllTracked
        }

        public WorkerModel Add(WorkerModel worker)
        {
            return _mainContext.Workers.Add(worker).Entity;
        }

        public WorkerModel Delete(int workerId)
        {
            WorkerModel? toRemove = GetById(workerId);
            if (toRemove == null)
            {
                throw new ArgumentException();
            }
            return _mainContext.Workers.Remove(toRemove).Entity;
        }
    }
}
