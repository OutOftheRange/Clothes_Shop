using Microsoft.AspNetCore.Mvc;
using ClothesShop.Services.Models.Authentication;
using ClothesShop.Services.Interfaces;
using FluentValidation;

namespace ClothesShop.WebAPI.Controllers
{
    [Route("api/authentication")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        IAuthenticationService _authenticationService;
        IValidator<RegisterData> _validator;

        public AuthenticationController(IAuthenticationService authenticationService, IValidator<RegisterData> validator) {
            _authenticationService = authenticationService;
            _validator = validator;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterData registerData)
        {
            var validationResult = _validator.Validate(registerData);
            var result = await _authenticationService.Register(registerData);

            if (validationResult.IsValid)
            {
                return result.Result == true ? Ok(result) : BadRequest(result);

            }
            return BadRequest(validationResult.Errors);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginData loginData)
        {
            var result = await _authenticationService.Login(loginData);

            return result.Result == true ? Ok(result) : BadRequest(result);

        }
    }
}
