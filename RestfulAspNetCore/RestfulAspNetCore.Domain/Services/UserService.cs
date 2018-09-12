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

        public User GetByEmailAndRefreshToken(string email, string refreshToken)
        {
            return _userRepo.GetByEmailAndRefreshToken(email, refreshToken);
        }

        public User Add(User user)
        {
            return _userRepo.Add(user);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public User Update(User user)
        {
            return _userRepo.Update(user);
        }

        public void Remove(string email)
        {
            _userRepo.Remove(email);
        }
    }
}
