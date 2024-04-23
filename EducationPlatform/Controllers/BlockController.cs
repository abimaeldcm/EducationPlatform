using EducationPlatform.Application.Interface;
using EducationPlatform.Domain.Entity;
using EducationPlatform.Domain.Entity.Enum;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EducationPlatform.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class BlockController : ControllerBase
    {
        private readonly ICRUDService<BlockOutput, BlockInput> _service;
        private readonly IValidator<BlockInput> _validator;

        public BlockController(ICRUDService<BlockOutput, BlockInput> service, IValidator<BlockInput> validator)
        {
            _service = service;
            _validator = validator;
        }

        [HttpGet]
        public async Task<ActionResult<List<BlockOutput>>> GetAll()
        {
            return Ok(await _service.GetAll());
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<BlockOutput>> FindById(int id)
        {
            return Ok(await _service.FindById(id));
        }

        [HttpPost]
      //  [Authorize(Roles = nameof(EAccessLevel.Manager))]
        public async Task<ActionResult<BlockOutput>> Create([FromBody] BlockInput create)
        {
            var result = _validator.Validate(create);
            if (!result.IsValid)
            {
                return BadRequest(result.Errors);
            }
            return Ok(await _service.Create(create));
        }

        [HttpPut("{id:int}")]
      //  [Authorize(Roles = nameof(EAccessLevel.Manager))]
        public async Task<ActionResult<BlockOutput>> Update(int id, [FromBody] BlockInput update)
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
