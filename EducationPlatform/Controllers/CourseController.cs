using EducationPlatform.Application.Interface;
using EducationPlatform.Domain.Entity;
using EducationPlatform.Domain.Entity.Enum;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EducationPlatform.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
 //   [Authorize]
    public class CourseController : ControllerBase
    {
        private readonly ICRUDService<CourseOutput, CourseInput> _service;
        private readonly IValidator<CourseInput> _validator;

        public CourseController(ICRUDService<CourseOutput, CourseInput> service, IValidator<CourseInput> validator)
        {
            _service = service;
            _validator = validator;
        }

        [HttpGet]
        public async Task<ActionResult<List<CourseOutput>>> GetAll()
        {
            return Ok(await _service.GetAll());
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<CourseOutput>> FindById(int id)
        {
            return Ok(await _service.FindById(id));
        }
        [HttpPost]
       // [Authorize(Roles = nameof(EAccessLevel.Manager))]
        public async Task<ActionResult<CourseOutput>> Create([FromBody] CourseInput create)
        {
            var result = _validator.Validate(create);
            if (!result.IsValid)
            {
                return BadRequest(result.Errors);
            }
            return Ok(await _service.Create(create));
        }

        [HttpPut("{id:int}")]
       // [Authorize(Roles = nameof(EAccessLevel.Manager))]
        public async Task<ActionResult<CourseOutput>> Update(int id, [FromBody] CourseInput update)
        {

            var result = _validator.Validate(update);
            if (!result.IsValid)
            {
                return BadRequest(result.Errors);
            }
            return Ok(await _service.Update(id, update));
        }

        [HttpDelete("{id}")]
       // [Authorize(Roles = nameof(EAccessLevel.Manager))]
        public async Task<ActionResult<bool>> Delete(int id)
        {
            return Ok(await _service.Delete(id));
        }
    }
}
