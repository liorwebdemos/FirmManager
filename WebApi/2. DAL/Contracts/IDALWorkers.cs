using PopDb.Models;

namespace WebApi.DAL.Contracts
{
    public interface IDALWorkers
    {
        WorkerModel? GetById(int workerId);

        IQueryable<WorkerModel> GetAll();
    }
}
