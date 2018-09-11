using System;
using System.Collections.Generic;
using RestfulAspNetCore.Domain.Entities;
using RestfulAspNetCore.Domain.Interfaces;
using RestfulAspNetCore.Domain.InterfacesRepo;

namespace RestfulAspNetCore.Domain.Services
{
    public class UserService : IUserService
    {

        IUserRepo _userRepo;

        public UserService(IUserRepo userRepo)
        {
            _userRepo = userRepo;
        }

        public User GetByEmail(string email)
        {
            return _userRepo.GetByEmail(email);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
