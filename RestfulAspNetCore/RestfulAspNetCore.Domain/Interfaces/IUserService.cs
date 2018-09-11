using System;
using System.Collections.Generic;
using RestfulAspNetCore.Domain.Entities;

namespace RestfulAspNetCore.Domain.Interfaces
{
    public interface IUserService : IDisposable
    {
        User GetByEmail(string email);
    }
}
