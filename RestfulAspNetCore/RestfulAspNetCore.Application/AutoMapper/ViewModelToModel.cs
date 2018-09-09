using System;
using AutoMapper;
using RestfulAspNetCore.Application.Model;
using RestfulAspNetCore.Domain.Entities;

namespace RestfulAspNetCore.Application.AutoMapper
{
	public class ViewModelToModel : Profile
    {
        public ViewModelToModel()
        {
            CreateMap<PersonModel, Person>();
        }
    }
}
