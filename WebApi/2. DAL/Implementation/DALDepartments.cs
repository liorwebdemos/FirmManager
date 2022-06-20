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

        public IQueryable<DepartmentModel> GetAll()
        {
            return _mainContext.Departments;
        }
    }
}
