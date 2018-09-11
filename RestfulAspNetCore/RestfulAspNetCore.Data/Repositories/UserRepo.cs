using Microsoft.EntityFrameworkCore;
using RestfulAspNetCore.Data.Context;
using RestfulAspNetCore.Domain.Entities;
using RestfulAspNetCore.Domain.InterfacesRepo;
using System.Linq;

namespace RestfulAspNetCore.Data.Repositories
{
    public class UserRepo : IUserRepo
    {

        protected readonly ContextApp Db;
        protected readonly DbSet<User> DbSet;

        public UserRepo(ContextApp context)
        {
            Db = context;
            DbSet = Db.Set<User>();
        }

        public User GetByEmail(string email)
        {
            return DbSet.Find(email);
        }
    }
}
