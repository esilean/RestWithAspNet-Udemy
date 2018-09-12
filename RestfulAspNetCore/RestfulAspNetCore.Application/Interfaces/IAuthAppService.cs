using RestfulAspNetCore.Application.Model;
using System;

namespace RestfulAspNetCore.Application.Interfaces
{
    public interface IAuthAppService : IDisposable
    {

        TokenResponseModel Auth(UserLoginModel userLoginModel);
    }
}
