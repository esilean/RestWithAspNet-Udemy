using System;
using System.Collections.Generic;
using System.Threading;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RestfulAspNetCore.Application.Interfaces;
using RestfulAspNetCore.Application.Model;
using RestfulAspNetCore.Domain.Entities;
using RestfulAspNetCore.Domain.Interfaces;
using RestfulAspNetCore.Domain.InterfacesRepo;
using RestfulAspNetCore.Domain.Services;
using RestfulAspNetCore.Helper;

namespace RestfulAspNetCore.Application.Services
{
    public class UserAppService : AppService, IUserAppService
    {

        private readonly IMapper _mapper;
        private readonly IUserService _userService;

        public UserAppService(IMapper mapper, IUserService userService, IUnitOfWork uow) : base(uow)
        {
            _userService = userService;
            _mapper = mapper;
        }

        public UserModel Add(UserModel userModel)
        {

            var user = _mapper.Map<User>(userModel);

            var userExist = _userService.GetByEmail(user.Email);
            if (userExist != null)
                throw new Exception("User is already taken!");

            byte[] passwordHash, passwordSalt;
            PasswordHelper.CreatePasswordHash(userModel.Password, out passwordHash, out passwordSalt);

            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;
            user.Created = DateTime.Now;
            user.IsActive = true;

            _userService.Add(user);

            Commit();

            return _mapper.Map<UserModel>(user);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }


    }
}
