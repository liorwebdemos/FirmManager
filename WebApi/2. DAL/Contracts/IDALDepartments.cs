using PopDb.Models;

namespace WebApi.DAL.Contracts
{
    public interface IDALDepartments
    {
        DepartmentModel? GetById(int departmentId);

        IQueryable<DepartmentModel> GetAll();
    }
}
