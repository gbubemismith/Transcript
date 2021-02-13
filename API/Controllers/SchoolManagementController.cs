using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class SchoolManagementController : ControllerBase
    {
        private readonly IGenericRepository<School> _schoolRepo;
        private readonly IGenericRepository<SchoolDepartment> _deptRepo;
        private readonly IGenericRepository<SchoolFaculty> _facultyRepo;

        public SchoolManagementController(IGenericRepository<School> schoolRepo, IGenericRepository<SchoolDepartment> deptRepo, IGenericRepository<SchoolFaculty> facultyRepo)
        {
            _schoolRepo = schoolRepo;
            _deptRepo = deptRepo;
            _facultyRepo = facultyRepo;
        }

        // public async Task<IActionResult> GetSchools()
        // {
        //     return Ok();
        // }
    }
}