using WebApi.Models;

namespace WebApi.BL.Contracts
{
    public interface IBLDepartments
    {
        DepartmentModel? GetDepartmentById(int departmentId, bool isWithWorkers);

        IEnumerable<DepartmentModel> GetDepartments(bool isWithWorkers);

        DepartmentModel AddDepartment(DepartmentModel department); //, int[] workersIdsToAssociate // a little ugly param, but didn't want to implement this https://stackoverflow.com/a/27177623

        DepartmentModel DeleteDepartment(int departmentId);

        DepartmentModel UpdateDepartment(DepartmentModel department); //, int[] workersIdsToAssociate // a little ugly param, but didn't want to implement this https://stackoverflow.com/a/27177623

        DepartmentModel SetDepartmentWorkers(int departmentId, int[] workersIds);
    }
}
