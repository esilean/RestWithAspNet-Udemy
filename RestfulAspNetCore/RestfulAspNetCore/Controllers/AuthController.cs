using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
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
        private IUserAppService _userAppService;

        public AuthController(IUserAppService userAppService)
        {
            _userAppService = userAppService;
        }


        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody]UserLoginModel loginModel)
        {

            if (loginModel.Grant_type == "password")
            {
                //return new OkResult(DoPassword(parameters));
                return Ok();
            }
            else if (loginModel.Grant_type == "refresh_token")
            {
                //return new OkObjectResult(DoRefreshToken(parameters));
                return Ok();
            }
            else
            {
                // validar errorDetail
                return new BadRequestObjectResult(new ErrorDetail
                {
                    Title = "",
                    Status = 400,
                    Detail = "!",
                    InnerMessage = "",
                    Instance = ""
                });
            }

        }



    }
}
