using RestfulAspNetCore.Domain.Entities;

namespace RestfulAspNetCore.Domain.InterfacesRepo
{
    public interface IPersonRepo : IRepo<Person>
    {
        Person FindByName(string firstName);
    }
}
