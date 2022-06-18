using PopDb.Models;

namespace WebApi.BL.Contracts
{
    public interface IBLDepartments
    {
        IEnumerable<DepartmentModel>? GetDepartments();
    }
}
