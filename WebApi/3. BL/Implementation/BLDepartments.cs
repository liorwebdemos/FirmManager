using WebApi.Models;
using WebApi.BL.Contracts;
using WebApi.DAL.Contracts;

namespace WebApi.BL.Implementation
{
    public class BLDepartments : IBLDepartments
    {
        private readonly IGenericRepo _genericRepo;

        public BLDepartments(IGenericRepo genericRepo)
        {
            _genericRepo = genericRepo;
        }

        public DepartmentModel? GetDepartmentById(int departmentId)
        {
            return _genericRepo.GetById<DepartmentModel>(departmentId);
        }

        public IEnumerable<DepartmentModel> GetDepartments()
        {
            return _genericRepo.GetAll<DepartmentModel>().ToList();
        }

        public DepartmentModel AddDepartment(DepartmentModel department)
        {
            _genericRepo.Add(department);
            _genericRepo.SaveChanges();
            return department;
        }

        public DepartmentModel DeleteDepartment(int departmentId)
        {
            DepartmentModel toDelete = _genericRepo.Delete<DepartmentModel>(departmentId);
            _genericRepo.SaveChanges();
            return toDelete;
        }

        public DepartmentModel UpdateDepartment(DepartmentModel department)
        {
            DepartmentModel? toUpdate = _genericRepo.GetById<DepartmentModel>(department.Id);
            if (toUpdate == null)
            {
                throw new ArgumentException();
            }
            // note: in a large-scale application, we'd use a tool to automate our mappings (like Mapster)
            toUpdate.Title = department.Title;
            toUpdate.Description = department.Description;
            toUpdate.IsActive = department.IsActive;
            _genericRepo.SaveChanges();
            return toUpdate;
        }
    }
}
