using Application.Contracts;
using Application.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/subjects")]
    [ApiController]
    public class SubjectsController : Controller
    {
        private readonly ISubjectService _subjectService;

        public SubjectsController(ISubjectService subjectService)
        {
            _subjectService = subjectService;
        }

        [Authorize(Roles = "Normal")]
        [HttpGet]
        public async Task<IActionResult> GetSubjects([FromQuery] int subjectNumber)
        {
            return Ok(await _subjectService.GetSubjects(subjectNumber));
        }

        [Authorize(Roles = "Normal")]
        [HttpGet("{subjectName}/students/{gender}")]
        public async Task<IActionResult> GetStudentsBySubject(string subjectName, string gender)
        {
            return Ok(await _subjectService.GetStudentsBySubject(subjectName, gender));
        }

        [Authorize(Roles = "Administrator")]
        [HttpPost("create")]
        public async Task<IActionResult> Create([FromForm] SubjectDto subjectCreate)
        {
            return Ok(await _subjectService.Create(subjectCreate));
        }

        [Authorize(Roles = "Administrator")]
        [HttpPut("update/{id}")]
        public async Task<IActionResult> Update(Guid id, [FromForm] SubjectDto subjectUpdate)
        {
            return Ok(await _subjectService.Update(id, subjectUpdate));
        }

        [Authorize(Roles = "Administrator")]
        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            return Ok(await _subjectService.Delete(id));
        }
    }
}