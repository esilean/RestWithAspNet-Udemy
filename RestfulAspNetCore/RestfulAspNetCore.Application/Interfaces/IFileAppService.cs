using RestfulAspNetCore.Application.Model;
using System;

namespace RestfulAspNetCore.Application.Interfaces
{
    public interface IUserAppService : IDisposable
    {
        UserModel Add(UserModel userModel);
    }
}
