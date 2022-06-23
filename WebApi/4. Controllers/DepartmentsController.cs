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
        public IEnumerable<DepartmentModel>? GetDepartments()
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

        //[HttpPut("{departmentId}")]
        //public DepartmentModel UpdateDepartmentById(int departmentId)
        //{
        //    return _blMovies.GetDepartmentById(departmentId);
        //}

        //https://docs.microsoft.com/en-us/ef/core/saving/cascade-delete
        //[HttpDelete("{departmentId}")]
        //public DepartmentModel DeleteDepartmentById(int departmentId)
        //{
        //    return _blMovies.GetDepartmentById(departmentId);
        //}
    }
}