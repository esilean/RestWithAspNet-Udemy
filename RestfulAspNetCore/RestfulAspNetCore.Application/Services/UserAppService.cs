using System;
using System.Collections.Generic;
using System.Threading;
using AutoMapper;
using RestfulAspNetCore.Application.Interfaces;
using RestfulAspNetCore.Application.Model;
using RestfulAspNetCore.Domain.Entities;
using RestfulAspNetCore.Domain.Interfaces;
using RestfulAspNetCore.Domain.InterfacesRepo;
using RestfulAspNetCore.Domain.Services;

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

        public UserLoginModel GetByEmail(string email)
        {
            // Logica



            return null;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }


    }
}
