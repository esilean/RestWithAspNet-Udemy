using System;
using System.Collections.Generic;
using System.Threading;
using AutoMapper;
using RestfulAspNetCore.Application.Interfaces;
using RestfulAspNetCore.Application.Model;
using RestfulAspNetCore.Domain.Entities;
using RestfulAspNetCore.Domain.Interfaces;
using RestfulAspNetCore.Domain.Services;

namespace RestfulAspNetCore.Application.Services
{
    public class PersonAppService : IPersonAppService
    {

        private readonly IMapper _mapper;
        private IPersonService _personService;

        public PersonAppService(IMapper mapper, IPersonService personService)
        {
            _personService = personService;
            _mapper = mapper;
        }

        public PersonModel Create(PersonModel person)
        {
            var p = _mapper.Map<Person>(person);
            _personService.Create(p);

            return _mapper.Map<PersonModel>(p);
        }

        public void Delete(long id)
        {
            _personService.Delete(id);
        }

        public List<PersonModel> FindAll()
        {

            var persons = _personService.FindAll();

            return _mapper.Map<List<PersonModel>>(persons);

            //var personModelList = new List<PersonModel>();
            //foreach (var p in persons)
            //{
            //    personModelList.Add(new PersonModel
            //    {
            //        Id = p.Id,
            //        FirstName = p.FirstName,
            //        LastName = p.LastName,
            //        Address = p.Address,
            //        Gender = p.Gender
            //    });
            //}

            //return personModelList;
        }

        public PersonModel FindById(long id)
        {
            var person = _personService.FindById(id);
            return _mapper.Map<PersonModel>(person);
        }

        public PersonModel Update(PersonModel person)
        {
            var p = _mapper.Map<Person>(person);
            _personService.Update(p);
            return _mapper.Map<PersonModel>(p);
        }

    }
}
