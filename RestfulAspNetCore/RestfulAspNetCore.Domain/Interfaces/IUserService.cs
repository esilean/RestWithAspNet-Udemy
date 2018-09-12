using System;
using System.Collections.Generic;
using RestfulAspNetCore.Domain.Entities;

namespace RestfulAspNetCore.Domain.Interfaces
{
    public interface IUserService : IDisposable
    {
        User GetByEmail(string email);
        User GetByEmailAndRefreshToken(string email, string refreshToken);

        User Add(User user);
        User Update(User user);
        void Remove(string email);
    }
}
