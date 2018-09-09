using System;
using System.Collections.Generic;
using RestfulAspNetCore.Domain.Entities;
using RestfulAspNetCore.Domain.Interfaces;
using RestfulAspNetCore.Domain.InterfacesRepo;

namespace RestfulAspNetCore.Domain.Services
{
    public class PersonService : IPersonService
    {

        IPersonRepo _personRepo;

        public PersonService(IPersonRepo personRepo)
        {
            _personRepo = personRepo;
        }

        public Person Create(Person person)
        {
            return _personRepo.Create(person);
        }

        public void Delete(long id)
        {
            _personRepo.Delete(id);
        }

        public List<Person> FindAll()
        {
            return  _personRepo.FindAll();
        }

        public Person FindById(long id)
        {
            return _personRepo.FindById(id);
        }

        public Person Update(Person person)
        {
            return _personRepo.Update(person);
        }
    }
}
