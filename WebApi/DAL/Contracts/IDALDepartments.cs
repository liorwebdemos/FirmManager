using PopDb.Models;

namespace WebApi.DAL.Contracts
{
    public interface IDALDepartments
    {
        IEnumerable<DepartmentModel>? GetDepartments();
    }
}
