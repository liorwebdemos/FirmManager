using PopDb.Models;

namespace WebApi.BL.Contracts
{
    public interface IBLWorkers
    {
        WorkerModel? GetWorkerById(int workerId);

        IEnumerable<WorkerModel> GetWorkers();

        WorkerModel AddWorker(WorkerModel worker);

        WorkerModel DeleteWorker(int workerId);

        WorkerModel UpdateWorker(WorkerModel worker);
    }
}
