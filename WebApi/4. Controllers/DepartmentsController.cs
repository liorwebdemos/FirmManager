using Microsoft.AspNetCore.Mvc;
using WebApi.Models;
using WebApi.BL.Contracts;

namespace WebApi.Controllers
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
        public IEnumerable<DepartmentModel> GetDepartments(bool isWithWorkers = false)
        {
            return _blMovies.GetDepartments(isWithWorkers);
        }

        [HttpGet("{departmentId}")]
        public DepartmentModel? GetDepartmentById(int departmentId, bool isWithWorkers = false)
        {
            return _blMovies.GetDepartmentById(departmentId, isWithWorkers);
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
        public DepartmentModel DeleteDepartment(int departmentId) // can add parameter shouldDeleteWorkers to state whether or not associated workers should be disassociated (their FK set to null) or deleted too
        {
            return _blMovies.DeleteDepartment(departmentId);
        }
    }
}