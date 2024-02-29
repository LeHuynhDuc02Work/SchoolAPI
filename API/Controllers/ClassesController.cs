using Application.Contracts;
using Application.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/classes")]
    [ApiController]
    public class ClassesController : Controller
    {
        private readonly IClassService _classService;

        public ClassesController(IClassService classService)
        {
            _classService = classService;
        }

        [Authorize(Roles = "Normal")]
        [HttpGet("{id}/students")]
        public async Task<IActionResult> GetStudents(Guid id, [FromQuery] InputSearchDto inputSearch)
        {
            return Ok(await _classService.GetStudents(id, inputSearch));
        }

        [Authorize(Roles = "Normal")]
        [HttpGet("{className}/highest-score-student")]
        public async Task<IActionResult> GetStudentHighestPoint(string className)
        {
            return Ok(await _classService.GetStudenHighestPointInClass(className));
        }

        [Authorize(Roles = "Normal")]
        [HttpGet("{className}/average-point")]
        public async Task<IActionResult> GetAveragePointOfClass(string className)
        {
            return Ok(await _classService.GetAveragePointOfClass(className));
        }

        [Authorize(Roles = "Administrator")]
        [HttpPost("create")]
        public async Task<IActionResult> Create([FromForm] ClassDto classCreate)
        {
            return Ok(await _classService.Create(classCreate));
        }

        [Authorize(Roles = "Administrator")]
        [HttpPut("update/{id}")]
        public async Task<IActionResult> Update(Guid id, [FromForm] ClassDto classUpdate)
        {
            return Ok(await _classService.Update(id, classUpdate));
        }

        [Authorize(Roles = "Administrator")]
        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            return Ok(await _classService.Delete(id));
        }
    }
}