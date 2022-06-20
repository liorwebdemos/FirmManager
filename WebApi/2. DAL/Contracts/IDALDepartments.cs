using PopDb.Models;

namespace WebApi.DAL.Contracts
{
    public interface IDALDepartments
    {
        IQueryable<DepartmentModel> GetAll();
    }
}
