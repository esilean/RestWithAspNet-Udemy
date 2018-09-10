using System;
using System.Collections.Generic;
using RestfulAspNetCore.Application.Model;

namespace RestfulAspNetCore.Application.Interfaces
{
    public interface IPersonAppService : IDisposable
    {
        PersonModel Add(PersonModel person);
        PersonModel FindById(int id);
        List<PersonModel> FindAll();
        PersonModel Update(PersonModel person);
        void Remove(int id);
    }
}
