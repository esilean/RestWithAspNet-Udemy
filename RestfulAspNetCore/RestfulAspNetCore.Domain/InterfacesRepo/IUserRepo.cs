using RestfulAspNetCore.Domain.Entities;

namespace RestfulAspNetCore.Domain.InterfacesRepo
{
    public interface IUserRepo
    {
        User GetByEmail(string email);
    }
}
