using Microsoft.AspNetCore.Mvc;
using PopDb.Models;
using WebApi.BL.Contracts;

namespace PopDb.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DepartmentsController : ControllerBase
    {
        private readonly IBLDepartments _blMovies;

        public DepartmentsController(IBLDepartments blMovies)
        {
            _blMovies = blMovies;
        }

        [HttpGet("")]
        public IEnumerable<DepartmentModel> GetDepartments()
        {
            return _blMovies.GetDepartments();
        }

        [HttpGet("{departmentId}")]
        public DepartmentModel? GetDepartmentById(int departmentId)
        {
            return _blMovies.GetDepartmentById(departmentId);
        }

        [HttpPost("")]
        public DepartmentModel AddDepartment([FromBody] DepartmentModel department)
        {
            return _blMovies.AddDepartment(department);
        }

        [HttpPut("")] // there's also REST convention of {departmentId}
        public DepartmentModel UpdateDepartment([FromBody] DepartmentModel department)
        {
            return _blMovies.UpdateDepartment(department);
        }

        [HttpDelete("")]
        public DepartmentModel DeleteDepartment(int departmentId)
        {
            return _blMovies.DeleteDepartment(departmentId);
        }
    }
}