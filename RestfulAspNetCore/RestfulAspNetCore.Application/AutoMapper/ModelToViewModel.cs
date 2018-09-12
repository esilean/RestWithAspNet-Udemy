using System;
using AutoMapper;
using RestfulAspNetCore.Application.Model;
using RestfulAspNetCore.Domain.Entities;

namespace RestfulAspNetCore.Application.AutoMapper
{
    public class ModelToViewModel : Profile
    {
        public ModelToViewModel()
        {
            CreateMap<Person, PersonModel>();
            CreateMap<Book, BookModel>();
            CreateMap<User, UserLoginModel>();
            CreateMap<User, UserModel>();
        }
    }
}
