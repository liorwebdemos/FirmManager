using WebApi.Models;
using WebApi.BL.Contracts;
using WebApi.DAL.Contracts;

namespace WebApi.BL.Implementation
{
    public class BLDepartments : IBLDepartments
    {
        private readonly IDepartmentsRepo _departmentsRepo;

        public BLDepartments(IDepartmentsRepo departmentsRepo)
        {
            _departmentsRepo = departmentsRepo;
        }

        public DepartmentModel? GetDepartmentById(int departmentId, bool isWithWorkers)
        {
            return isWithWorkers
                ? _departmentsRepo.GetByIdWithWorkers(departmentId)
                : _departmentsRepo.GetById<DepartmentModel>(departmentId);
        }

        public IEnumerable<DepartmentModel> GetDepartments(bool isWithWorkers)
        {
            return (isWithWorkers
                ? _departmentsRepo.GetAllWithWorkers()
                : _departmentsRepo.GetAll<DepartmentModel>())
                .ToList();
        }

        public DepartmentModel AddDepartment(DepartmentModel department)
        {
            _departmentsRepo.Add(department);
            _departmentsRepo.SaveChanges();
            return department;
        }

        public DepartmentModel DeleteDepartment(int departmentId)
        {
            DepartmentModel toDelete = _departmentsRepo.Delete<DepartmentModel>(departmentId);
            _departmentsRepo.SaveChanges();
            return toDelete;
        }

        public DepartmentModel UpdateDepartment(DepartmentModel department)
        {
            DepartmentModel? toUpdate = _departmentsRepo.GetById<DepartmentModel>(department.Id);
            if (toUpdate == null)
            {
                throw new ArgumentException();
            }
            // note: in a large-scale application, we'd use a tool to automate our mappings (like Mapster)
            toUpdate.Title = department.Title;
            toUpdate.Description = department.Description;
            toUpdate.IsActive = department.IsActive;
            _departmentsRepo.SaveChanges();
            return toUpdate;
        }
    }
}
