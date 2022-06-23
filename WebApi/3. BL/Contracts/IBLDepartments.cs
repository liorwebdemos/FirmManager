using PopDb.Models;

namespace WebApi.BL.Contracts
{
    public interface IBLDepartments
    {
        DepartmentModel? GetDepartmentById(int departmentId);

        IEnumerable<DepartmentModel> GetDepartments();
    }
}
