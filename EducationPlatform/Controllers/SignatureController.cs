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
    //[Authorize(Roles = nameof(EAccessLevel.Manager))]
    public class SignatureController : ControllerBase
    {
        private readonly ICRUDService<SignatureOutput, SignatureInput> _service;
        private readonly IValidator<SignatureInput> _validator;

        public SignatureController(ICRUDService<SignatureOutput, SignatureInput> service, IValidator<SignatureInput> validator)
        {
            _service = service;
            _validator = validator;
        }

        [HttpGet]        
        public async Task<ActionResult<List<SignatureOutput>>> GetAll()
        {
            return Ok(await _service.GetAll());
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<SignatureOutput>> FindById(int id)
        {
            return Ok(await _service.FindById(id));
        }

        [HttpPost]
        public async Task<ActionResult<SignatureOutput>> Create([FromBody] SignatureInput create)
        {
            var result = _validator.Validate(create);
            if (!result.IsValid)
            {
                return BadRequest(result.Errors);
            }
            return Ok(await _service.Create(create));
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<SignatureOutput>> Update(int id, [FromBody] SignatureInput update)
        {

            var result = _validator.Validate(update);
            if (!result.IsValid)
            {
                return BadRequest(result.Errors);
            }
            return Ok(await _service.Update(id, update));
        }

        [HttpDelete("{id}")]
        //[Authorize(Roles = "manager")]
        public async Task<ActionResult<bool>> Delete(int id)
        {
            return Ok(await _service.Delete(id));
        }
    }
}
