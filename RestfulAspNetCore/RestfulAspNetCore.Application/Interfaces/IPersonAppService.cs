using System.Collections.Generic;
using RestfulAspNetCore.Application.Model;

namespace RestfulAspNetCore.Application.Interfaces
{
    public interface IPersonAppService
    {
        PersonModel Create(PersonModel person);
        PersonModel FindById(long id);
        List<PersonModel> FindAll();
        PersonModel Update(PersonModel person);
        void Delete(long id);
    }
}
