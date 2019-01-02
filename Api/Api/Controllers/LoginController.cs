
namespace Api.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Contracts.Security;
    using Api.Models;

    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {

        private readonly ILoginService _loginService;

        public LoginController(ILoginService loginService)
        {
            _loginService = loginService;
        }

        // POST api/Login
        [HttpPost]
        public IActionResult Post([FromBody] LoginViewModel login)
        {

            var token = _loginService.LoginUser(new LoginUserRequest
            {
                UserName = login.Usuario,
                Password = login.Password
            });

            return Ok(token);
        }

        [HttpGet]
        public IActionResult Get()
        {
            //return Ok(_loginService.Initializer(new Contracts.Security.Initializer.InitializerRequest { }));
            return Ok();
        }

    }
}
