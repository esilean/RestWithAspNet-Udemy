using RestfulAspNetCore.Domain.Entities;

namespace RestfulAspNetCore.Domain.InterfacesRepo
{
    public interface IUserRepo : IRepo<User>
    {
        User GetByEmail(string email);
        User GetByEmailAndRefreshToken(string email, string refreshToken);

        void Remove(string email);
    }
}
