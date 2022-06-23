using PopDb.Models;
using WebApi.BL.Contracts;
using WebApi.DAL.Contracts;

namespace WebApi.BL.Implementation
{
    public class BLDepartments : IBLDepartments
    {
        private readonly IDALDepartments _dalDepartments;

        public BLDepartments(IDALDepartments dalDepartments)
        {
            _dalDepartments = dalDepartments;
        }

        public DepartmentModel? GetDepartmentById(int departmentId)
        {
            return _dalDepartments.GetById(departmentId);
        }

        public IEnumerable<DepartmentModel> GetDepartments()
        {
            return _dalDepartments.GetAll().ToList();
        }

        public DepartmentModel AddDepartment(DepartmentModel department)
        {
            _dalDepartments.Add(department);
            _dalDepartments.SaveChanges();
            return department;
        }

        public DepartmentModel DeleteDepartment(int departmentId)
        {
            DepartmentModel toDelete = _dalDepartments.Delete(departmentId);
            _dalDepartments.SaveChanges();
            return toDelete;
        }

        public DepartmentModel UpdateDepartment(DepartmentModel department)
        {
            DepartmentModel? toUpdate = _dalDepartments.GetById(department.Id);
            if (toUpdate == null)
            {
                throw new ArgumentException();
            }
            // note: in a large-scale application, we'd use a tool to automate our mappings (like Mapster)
            toUpdate.Title = department.Title;
            toUpdate.Description = department.Description;
            toUpdate.IsActive = department.IsActive;
            _dalDepartments.SaveChanges();
            return toUpdate;
        }
    }
}
