using WebApi.Models;

namespace WebApi.BL.Contracts
{
    public interface IBLDepartments
    {
        DepartmentModel? GetDepartmentById(int departmentId, bool isWithWorkers);

        IEnumerable<DepartmentModel> GetDepartments(bool isWithWorkers);

        DepartmentModel AddDepartment(DepartmentModel department);

        DepartmentModel DeleteDepartment(int departmentId);

        DepartmentModel UpdateDepartment(DepartmentModel department);
    }
}
