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

        public IEnumerable<DepartmentModel>? GetDepartments()
        {
            return _dalDepartments.GetDepartments();
        }
    }
}
