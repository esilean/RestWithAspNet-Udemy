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

        public Person Add(Person person)
        {
            return _personRepo.Add(person);
        }

        public void Remove(int id)
        {
            _personRepo.Remove(id);
        }

        public List<Person> FindAll()
        {
            return _personRepo.FindAll();
        }

        public Person FindById(int id)
        {
            return _personRepo.FindById(id);
        }

        public Person Update(Person person)
        {
            return _personRepo.Update(person);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
