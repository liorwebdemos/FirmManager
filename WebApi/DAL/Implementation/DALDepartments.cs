using PopDb.Models;
using WebApi.DAL.Contracts;

namespace WebApi.DAL.Implementation
{
    public class DALDepartments : IDALDepartments
    {
        private readonly ILogger<DALDepartments> _logger;

        public DALDepartments(
            //IConfiguration configuration,
            ILogger<DALDepartments> logger
        )
        {
            _logger = logger;
        }

        public IEnumerable<DepartmentModel>? GetDepartments()
        {
            return null;
        }
    }
}
