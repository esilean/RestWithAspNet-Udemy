using Microsoft.AspNetCore.Mvc;
using RestfulAspNetCore.Application.Interfaces;
using RestfulAspNetCore.Application.Model;
using RestfulAspNetCore.Services.ErrorHandling;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RestfulAspNetCore.Services.Controllers
{
    [ApiVersion("1")]
    [Route("api/[controller]/v{version:apiVersion}")]
    [ApiController]
    public class AuthController : Controller
    {
        //private IOptions<Audience> _settings;
        private readonly IAuthAppService _authAppService;

        public AuthController(IAuthAppService authAppService)
        {
            _authAppService = authAppService;
        }


        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody]UserLoginModel loginModel)
        {

            var tokenResponse = _authAppService.Auth(loginModel);

            if (tokenResponse != null) return Ok(tokenResponse);

            return BadRequest(new ErrorDetail
            {
                Title = "Authentication Failed",
                Status = 400,
                Detail = "User and/or Password invalid!"
            });
        }

    }
}
