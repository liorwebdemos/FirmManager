using WebApi.Models;

namespace WebApi.DAL.Contracts
{
    public interface IDepartmentsRepo : IGenericRepo
    {
        DepartmentModel? GetByIdWithWorkers(int entityId);

        IQueryable<DepartmentModel> GetAllWithWorkers();
    }
}
