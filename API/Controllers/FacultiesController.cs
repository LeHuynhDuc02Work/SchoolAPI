using Application.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace API.Controllers
{
    [Route("api/faculties")]
    [ApiController]
    public class FacultiesController : Controller
    {
        private readonly IFacultyService _facultyService;

        public FacultiesController(IFacultyService facultyService)
        {
            _facultyService = facultyService;
        }

        [Authorize(Roles = "Normal")]
        [HttpGet("{facultyName}/subjects")]
        public async Task<IActionResult> GetSubjectsOfFaculty(string facultyName)
        {
            return Ok(await _facultyService.GetSubjectsOfFaculty(facultyName));
        }
    }
}
