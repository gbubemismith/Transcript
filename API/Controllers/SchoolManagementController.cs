using System.Threading.Tasks;
using API.Errors;
using Core.Entities;
using Core.Interfaces;
using Core.Interfaces.services;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class SchoolManagementController : ControllerBase
    {
        private readonly ISchoolManagementService _schoolService;

        public SchoolManagementController(ISchoolManagementService schoolService)
        {
            _schoolService = schoolService;

        }

        [HttpGet("GetSchoolById/{id}")]
        public async Task<IActionResult> GetSchoolById(int id)
        {
            var school = await _schoolService.GetSchoolById(id);

            if (school == null)
                return NotFound(new ApiResponse(404));

            return Ok(school);
        }


    }
}