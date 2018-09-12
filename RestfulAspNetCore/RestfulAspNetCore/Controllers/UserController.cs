using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestfulAspNetCore.Application.Interfaces;
using RestfulAspNetCore.Application.Model;

namespace RestfulAspNetCore.Services.Controllers
{
    [ApiVersion("1")]
    [Route("api/[controller]/v{version:apiVersion}")]
    [ApiController]
    public class UserController : Controller
    {
        //private IOptions<Audience> _settings;
        private IUserAppService _userAppService;

        public UserController(IUserAppService userAppService)
        {
            _userAppService = userAppService;
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult Register([FromBody]UserModel userModel)
        {
            var user = _userAppService.Add(userModel);
            return Ok();
        }
    }
}