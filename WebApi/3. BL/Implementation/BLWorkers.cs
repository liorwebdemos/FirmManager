using PopDb.Models;
using WebApi.BL.Contracts;
using WebApi.DAL.Contracts;

namespace WebApi.BL.Implementation
{
    public class BLWorkers : IBLWorkers
    {
        private readonly IDALWorkers _dalWorkers;

        public BLWorkers(IDALWorkers dalWorkers)
        {
            _dalWorkers = dalWorkers;
        }

        public WorkerModel? GetWorkerById(int departmentId)
        {
            return _dalWorkers.GetById(departmentId);
        }

        public IEnumerable<WorkerModel> GetWorkers()
        {
            return _dalWorkers.GetAll().ToList();
        }
    }
}