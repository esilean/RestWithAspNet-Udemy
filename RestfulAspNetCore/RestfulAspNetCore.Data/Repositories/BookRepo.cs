using RestfulAspNetCore.Data.Context;
using RestfulAspNetCore.Domain.Entities;
using RestfulAspNetCore.Domain.InterfacesRepo;

namespace RestfulAspNetCore.Data.Repositories
{
    public class BookRepo : Repository<Book>, IBookRepo
    {

        public BookRepo(ContextApp context) : base(context) { }
    }
}
