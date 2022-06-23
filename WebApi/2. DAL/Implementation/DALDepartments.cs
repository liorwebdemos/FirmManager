using Microsoft.EntityFrameworkCore;
using PopDb.Models;
using WebApi.DAL.Contracts;
using WebApi.DAL.Implementation.Contexts;

namespace WebApi.DAL.Implementation
{
    public class DALDepartments : IDALDepartments
    {
        private readonly ILogger<DALDepartments> _logger;
        private readonly MainContext _mainContext;

        public DALDepartments(
            ILogger<DALDepartments> logger,
            MainContext mainContext
        )
        {
            _logger = logger;
            _mainContext = mainContext;
        }

        public void SaveChanges()
        {
            _mainContext.SaveChanges();
        }

        public DepartmentModel? GetById(int departmentId)
        {
            return _mainContext.Departments.Find(departmentId);
        }

        public IQueryable<DepartmentModel> GetAll()
        {
            return _mainContext.Departments.AsNoTracking(); // tracking is expensive. if we need to, we can also create GetAllTracked
        }

        public DepartmentModel Add(DepartmentModel department)
        {
            return _mainContext.Departments.Add(department).Entity;
        }

        public DepartmentModel Delete(int departmentId)
        {
            DepartmentModel? toRemove = GetById(departmentId);
            if (toRemove == null)
            {
                throw new ArgumentException();
            }
            return _mainContext.Departments.Remove(toRemove).Entity;
        }
    }
}
