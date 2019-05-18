using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using ofco_projects_api.Services;
using ofco_projects_api.DataModel;
using ofco_projects_api.Repositories;

namespace ofco_projects_api.Controllers
{
    [Authorize]
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
        public IActionResult Authenticate([FromBody]User userParam)
        {
            var user = _loginRepository.Authenticate(userParam.Username, userParam.Password);

            if (user == null)
                return BadRequest(new { message = "Username or password is incorrect" });

            return Ok(user);
        }
    }
}