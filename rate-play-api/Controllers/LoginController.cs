using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using rate_play_api.Services;
using rate_play_api.DataModel;
using rate_play_api.Repositories;
using rate_play_api.Services.RatePlayContext;

namespace rate_play_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoginController : ControllerBase
    {
        private LoginRepository _loginRepository;

        public LoginController(LoginRepository userRepository)
        {
            _loginRepository = userRepository;
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody]Member userParam)
        {
            var user = _loginRepository.AuthenticateAsync(userParam.Email, userParam.Password);

            if (user == null)
                return BadRequest(new { message = "Username or password is incorrect" });

            return Ok(user);
        }
    }
}