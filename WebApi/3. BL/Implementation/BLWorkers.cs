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

        public WorkerModel? GetWorkerById(int workerId)
        {
            return _dalWorkers.GetById(workerId);
        }

        public IEnumerable<WorkerModel> GetWorkers()
        {
            return _dalWorkers.GetAll().ToList();
        }

        public WorkerModel AddWorker(WorkerModel worker)
        {
            _dalWorkers.Add(worker);
            _dalWorkers.SaveChanges();
            return worker;
        }

        public WorkerModel DeleteWorker(int workerId)
        {
            WorkerModel toDelete = _dalWorkers.Delete(workerId);
            _dalWorkers.SaveChanges();
            return toDelete;
        }

        public WorkerModel UpdateWorker(WorkerModel worker)
        {
            WorkerModel? toUpdate = _dalWorkers.GetById(worker.Id);
            if (toUpdate == null)
            {
                throw new ArgumentException();
            }
            // note: in a large-scale application, we'd use a tool to automate our mappings (like Mapster)
            toUpdate.IsraeliIdentityNumber = worker.IsraeliIdentityNumber;
            toUpdate.FirstName = worker.FirstName;
            toUpdate.LastName = worker.LastName;
            toUpdate.Gender = worker.Gender;
            toUpdate.JobStartDate = worker.JobStartDate;
            toUpdate.JobEndDate = worker.JobEndDate;
            _dalWorkers.SaveChanges();
            return toUpdate;
        }
    }
}