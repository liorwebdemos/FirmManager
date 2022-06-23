using Microsoft.EntityFrameworkCore;
using PopDb.Models;
using WebApi.DAL.Contexts;
using WebApi.DAL.Contracts;

namespace WebApi.DAL.Implementation
{
    public class DALDepartments : IDALDepartments
    {
        private readonly ILogger<DALDepartments> _logger;
        private readonly MainContext _mainContext;

        public DALDepartments(
            //IConfiguration configuration,
            ILogger<DALDepartments> logger,
            MainContext mainContext
        )
        {
            _logger = logger;
            _mainContext = mainContext;
        }

        public DepartmentModel? GetById(int departmentId)
        {
            return _mainContext.Departments.FirstOrDefault(d => d.Id == departmentId);
        }

        public IQueryable<DepartmentModel> GetAll()
        {
            return _mainContext.Departments.AsNoTracking(); // tracking is expensive
        }
    }
}
