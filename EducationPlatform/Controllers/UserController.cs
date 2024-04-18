using EducationPlatform.Application.Interface;
using EducationPlatform.Application.Services.Token;
using EducationPlatform.Domain.Entity;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EducationPlatform.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ICRUDService<UserOutput, UserInput> _service;
        private readonly ILoginService _loginService;
        private readonly IValidator<UserInput> _validator;

        public UserController(ICRUDService<UserOutput, UserInput> service, ILoginService loginService, IValidator<UserInput> validator)
        {
            _service = service;
            _loginService = loginService;
            _validator = validator;
        }

        [HttpPost]
        [Route("Login")]
        [AllowAnonymous]
        public async Task<ActionResult<UserLogged>> Login(Login login)
        {
            var user = await _loginService.FindLogin(login.CPF, login.Password);
            if (user == null)
            {
                return NotFound("Usuario ou senha não localizado.");
            }

            var token = TokenService.GenerateToken(user);

            return new UserLogged
            {
                User = user,
                Token = token
            };
        }

        [HttpGet]
        public async Task<ActionResult<List<UserOutput>>> GetAll()
        {
            return Ok(await _service.GetAll());
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<UserOutput>> FindById(int id)
        {
            return Ok(await _service.FindById(id));
        }

        [HttpPost]
        public async Task<ActionResult<UserOutput>> Create(UserInput create)
        {
            var result = _validator.Validate(create);
            if (!result.IsValid)
            {
                return BadRequest(result.Errors);
            }
            return Ok(await _service.Create(create));
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<UserOutput>> Update(int id, UserInput update)
        {
            var result = _validator.Validate(update);
            if (!result.IsValid)
            {
                return BadRequest(result.Errors);
            }
            return Ok(await _service.Update(id, update));
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "manager")]
        public async Task<ActionResult<bool>> Delete(int id)
        {
            return Ok(await _service.Delete(id));
        }
    }
}