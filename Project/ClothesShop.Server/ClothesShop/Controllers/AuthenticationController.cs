using Microsoft.AspNetCore.Mvc;
using ClothesShop.Services.DTO.Authentication;
using ClothesShop.Services.Interfaces;

namespace ClothesShop.WebAPI.Controllers
{
    [Route("api/authentication")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        IAuthenticationService _authenticationService;
        public AuthenticationController(IAuthenticationService authenticationService) {
            _authenticationService = authenticationService;
        }
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterData registerData)
        {
            //validation

            //
            var result = await _authenticationService.Register(registerData);

            return result.Result == true ? Ok(result) : BadRequest(result);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginData loginData)
        {
            //validation

            //
            var result = await _authenticationService.Login(loginData);

            return result.Result == true ? Ok(result) : BadRequest(result);

        }
    }
}
