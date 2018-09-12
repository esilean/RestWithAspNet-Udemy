using System;
using System.Collections.Generic;
using RestfulAspNetCore.Domain.Entities;

namespace RestfulAspNetCore.Domain.Interfaces
{
    public interface IPersonService : IDisposable
    {
        Person Add(Person person);
        Person FindById(int id);
        List<Person> FindAll();
        List<Person> FindByName(string firstName, string lastName);
        Person Update(Person person);
        void Remove(int id);

        List<Person> FindWithPageSearch(string query);
    }
}
