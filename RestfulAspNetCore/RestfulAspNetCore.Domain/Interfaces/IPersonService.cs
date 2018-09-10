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
        Person Update(Person person);
        void Remove(int id);
    }
}
