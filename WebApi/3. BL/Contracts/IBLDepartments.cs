using WebApi.Models;

namespace WebApi.BL.Contracts
{
    public interface IBLDepartments
    {
        DepartmentModel? GetDepartmentById(int departmentId);

        IEnumerable<DepartmentModel> GetDepartments();

        DepartmentModel AddDepartment(DepartmentModel department);

        DepartmentModel DeleteDepartment(int departmentId);

        DepartmentModel UpdateDepartment(DepartmentModel department);
    }
}
