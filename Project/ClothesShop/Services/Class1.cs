using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;

namespace Services
{
    [Route("api/profile")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [HttpPost("register-services2")]
        public async Task<IActionResult> Register1()
        {
            return Ok(ModelState);

        }
    }
}