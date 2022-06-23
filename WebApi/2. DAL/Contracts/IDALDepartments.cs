using PopDb.Models;

namespace WebApi.DAL.Contracts
{
    public interface IDALDepartments
    {
        void SaveChanges();

        DepartmentModel? GetById(int departmentId);

        IQueryable<DepartmentModel> GetAll();

        DepartmentModel Add(DepartmentModel department);

        DepartmentModel Delete(int departmentId);
    }
}
