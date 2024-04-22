using EducationPlatform.Application.Interface;
using EducationPlatform.Application.Services.Token;
using EducationPlatform.Application.Validations.UserValidations;
using EducationPlatform.Domain.Entity;
using EducationPlatform.Domain.Entity.Enum;
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
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserController(ICRUDService<UserOutput, UserInput> service, ILoginService loginService, IValidator<UserInput> validator, IHttpContextAccessor httpContextAccessor)
        {
            _service = service;
            _loginService = loginService;
            _validator = validator;
            _httpContextAccessor = httpContextAccessor;
        }

        [HttpPost]
        [Route("Login")]
        [AllowAnonymous]
        public async Task<ActionResult<UserLogged>> Login(Login login)
        {
            try
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
            catch (Exception msg)
            {
                return Unauthorized(msg.Message);
            }
            
        }

        [HttpGet]
        public async Task<ActionResult<List<UserOutput>>> GetAll()
        {
            return Ok(await _service.GetAll());
        }

        [HttpGet("{id:int}")]
        [Authorize()]
        public async Task<ActionResult<UserOutput>> FindById(int id)
        {
            var user = _httpContextAccessor.HttpContext.User;

            if (!UserValidate.ValidateFindUser(id, user))
            {
                return Unauthorized();
            }

            return Ok(await _service.FindById(id));
        }

        [HttpPost]
        [Authorize(Roles = nameof(EAccessLevel.Manager))]
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
        [Authorize()]
        public async Task<ActionResult<UserOutput>> Update(int id, UserInput update)
        {
            var user = _httpContextAccessor.HttpContext.User;
            if (!UserValidate.ValidateFindUser(id, user))
            {
                return Unauthorized();
            }

            var result = _validator.Validate(update);
            if (!result.IsValid)
            {
                return BadRequest(result.Errors);
            }
            return Ok(await _service.Update(id, update));
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = nameof(EAccessLevel.Manager))]
        public async Task<ActionResult<bool>> Delete(int id)
        {
            return Ok(await _service.Delete(id));
        }
    }
}