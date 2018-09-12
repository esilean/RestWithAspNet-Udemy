using RestfulAspNetCore.Domain.Entities;
using System.Collections.Generic;

namespace RestfulAspNetCore.Domain.InterfacesRepo
{
    public interface IPersonRepo : IRepo<Person>
    {
        List<Person> FindByName(string firstName, string lastName);
    }
}
