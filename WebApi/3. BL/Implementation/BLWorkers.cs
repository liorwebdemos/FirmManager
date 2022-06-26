using WebApi.BL.Contracts;
using WebApi.DAL.Contracts;
using WebApi.Models;

namespace WebApi.BL.Implementation
{
    public class BLWorkers : IBLWorkers
    {
        private readonly IGenericRepo _genericRepo;
        private readonly IDepartmentsRepo _departmentsRepo;

        public BLWorkers(IGenericRepo genericRepo, IDepartmentsRepo departmentsRepo)
        {
            _genericRepo = genericRepo;
            _departmentsRepo = departmentsRepo;
        }

        public WorkerModel? GetWorkerById(int workerId)
        {
            return _genericRepo.GetById<WorkerModel>(workerId);
        }

        public IEnumerable<WorkerModel> GetWorkers()
        {
            return _genericRepo.GetAll<WorkerModel>().ToList();
        }

        public WorkerModel AddWorker(WorkerModel worker)
        {
            _genericRepo.Add(worker);
            _genericRepo.SaveChanges();
            return worker;
        }

        public WorkerModel DeleteWorker(int workerId)
        {
            WorkerModel toDelete = _genericRepo.Delete<WorkerModel>(workerId);
            _genericRepo.SaveChanges();
            return toDelete;
        }

        public WorkerModel UpdateWorker(WorkerModel worker)
        {
            WorkerModel? toUpdate = _genericRepo.GetById<WorkerModel>(worker.Id);
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

            _genericRepo.SaveChanges();
            return toUpdate;
        }
    }
}