using RestfulAspNetCore.Application.Model;
using System;

namespace RestfulAspNetCore.Application.Interfaces
{
    public interface IUserAppService : IDisposable
    {
        UserLoginModel GetByEmail(string email);
    }
}
