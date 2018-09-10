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
    public class PersonAppService : AppService, IPersonAppService
    {

        private readonly IMapper _mapper;
        private readonly IPersonService _personService;

        public PersonAppService(IMapper mapper, IPersonService personService, IUnitOfWork uow) : base(uow)
        {
            _personService = personService;
            _mapper = mapper;
        }

        public PersonModel Add(PersonModel person)
        {
            var p = _mapper.Map<Person>(person);
            _personService.Add(p);

            Commit();

            return _mapper.Map<PersonModel>(p);
        }

        public void Remove(int id)
        {
            _personService.Remove(id);
            Commit();
        }

        public List<PersonModel> FindAll()
        {

            var persons = _personService.FindAll();

            return _mapper.Map<List<PersonModel>>(persons);
        }

        public PersonModel FindById(int id)
        {
            var person = _personService.FindById(id);
            return _mapper.Map<PersonModel>(person);
        }

        public PersonModel Update(PersonModel person)
        {
            var p = _mapper.Map<Person>(person);
            _personService.Update(p);
            Commit();
            return _mapper.Map<PersonModel>(p);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

    }
}
