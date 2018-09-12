using Microsoft.EntityFrameworkCore;
using RestfulAspNetCore.Data.Context;
using RestfulAspNetCore.Domain.Entities;
using RestfulAspNetCore.Domain.InterfacesRepo;
using System.Linq;

namespace RestfulAspNetCore.Data.Repositories
{
    public class UserRepo : Repository<User>, IUserRepo
    {

        public UserRepo(ContextApp context) : base(context) { }

        public User GetByEmail(string email)
        {
            return DbSet.Find(email);
        }

        public User GetByEmailAndRefreshToken(string email, string refreshToken)
        {
            var user = GetByEmail(email);

            if (user != null)
            {
                if (user.RefreshToken == refreshToken)
                    return user;
            }

            return null;
        }

        public void Remove(string email)
        {
            DbSet.Remove(GetByEmail(email));
        }
    }
}
