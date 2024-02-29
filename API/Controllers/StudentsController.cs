using Application.Contracts;
using Application.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/students")]
    [ApiController]
    public class StudentsController : Controller
    {
        private readonly IStudentService _studentService;

        public StudentsController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpGet]
        [Authorize(Roles = "Normal")]
        public async Task<IActionResult> GetAll([FromQuery] InputSearchDto inputSearch)
        {
            return Ok(await _studentService.GetAll(inputSearch));
        }

        [Authorize(Roles = "Administrator")]
        [HttpPost("create")]
        public async Task<IActionResult> Create([FromForm] StudentDto studentCreate)
        {
            return Ok(await _studentService.Create(studentCreate));
        }

        [Authorize(Roles = "Administrator")]
        [HttpPut("update/{id}")]
        public async Task<IActionResult> Update(Guid id, [FromForm] StudentDto studentUpdate)
        {
            return Ok(await _studentService.Update(id, studentUpdate));
        }

        [Authorize(Roles = "Administrator")]
        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            return Ok(await _studentService.Delete(id));
        }
    }
}