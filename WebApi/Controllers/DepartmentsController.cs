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
    }
}