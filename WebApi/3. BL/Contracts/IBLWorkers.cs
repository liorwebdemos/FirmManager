using PopDb.Models;

namespace WebApi.BL.Contracts
{
    public interface IBLWorkers
    {
        WorkerModel? GetWorkerById(int departmentId);

        IEnumerable<WorkerModel> GetWorkers();
    }
}
