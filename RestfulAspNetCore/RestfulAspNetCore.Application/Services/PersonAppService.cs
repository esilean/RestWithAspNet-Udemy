using System;
using System.Collections.Generic;
using System.Threading;
using AutoMapper;
using RestfulAspNetCore.Application.Interfaces;
using RestfulAspNetCore.Application.Model;
using RestfulAspNetCore.Application.Model.Pagination;
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


        public PagedList<PersonModel> FindWithPageSearch(PagingParams pagingParams)
        {
            var persons = _personService.FindAll();
            var personsModel = _mapper.Map<List<PersonModel>>(persons);

            return new PagedList<PersonModel>(personsModel, pagingParams.PageNumber, pagingParams.PageSize);
        }

        public List<PersonModel> FindByName(string firstName, string lastName)
        {
            var persons = _personService.FindByName(firstName, lastName);

            return _mapper.Map<List<PersonModel>>(persons);
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
