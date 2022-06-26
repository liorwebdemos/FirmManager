using WebApi.Models;
using WebApi.BL.Contracts;
using WebApi.DAL.Contracts;
using WebApi.DAL.Implementation.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

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
            if (toUpdate == default)
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

        // TODO: definitely can be written better
        public DepartmentModel SetDepartmentWorkers(int departmentId, int[] toAssignWorkersIds)
        {
            DepartmentModel? department = _departmentsRepo.GetById<DepartmentModel>(departmentId);
            if (department == default)
            {
                throw new Exception();
            }

            IEnumerable<int> assignedWorkersIds = _departmentsRepo.GetAll<WorkerModel>()
                .Where(worker => worker.DepartmentId == departmentId)
                .Select(worker => worker.Id)
                .ToList();
            IEnumerable<int> influencedWorkersIds = assignedWorkersIds.Concat(toAssignWorkersIds);

            foreach (int id in influencedWorkersIds) // foreach is not very efficient (https://stackoverflow.com/a/21592733) but we won't update via the reference properites
            {
                // workers to add
                if (toAssignWorkersIds.Contains(id) && !assignedWorkersIds.Contains(id))
                {
                    var worker = _departmentsRepo.GetById<WorkerModel>(id);
                    if (worker == default)
                    {
                        throw new Exception();
                    }
                    worker.DepartmentId = departmentId;
                }
                // workers to unassign
                if (assignedWorkersIds.Contains(id) && !toAssignWorkersIds.Contains(id))
                {
                    var worker = _departmentsRepo.GetById<WorkerModel>(id);
                    if (worker == default)
                    {
                        throw new Exception();
                    }
                    worker.DepartmentId = null;
                }
            }

            _departmentsRepo.SaveChanges();
            return _departmentsRepo.GetByIdWithWorkers(departmentId)!;
        }

        // https://stackoverflow.com/a/27177623
        // https://docs.microsoft.com/en-us/aspnet/core/data/ef-mvc/update-related-data?view=aspnetcore-6.0#update-the-instructors-controller-1
        // https://www.learnentityframeworkcore.com/dbset/modifying-data + https://www.mikesdotnetting.com/article/303/entity-framework-core-trackgraph-for-disconnected-data
        // https://stackoverflow.com/a/55190929
        // https://stackoverflow.com/a/33059565 + https://github.com/zzzprojects/GraphDiff (no EF core version as of yet) + https://stackoverflow.com/a/21436713
        // https://stackoverflow.com/a/24910673 + https://stackoverflow.com/a/24907546
    }
}
