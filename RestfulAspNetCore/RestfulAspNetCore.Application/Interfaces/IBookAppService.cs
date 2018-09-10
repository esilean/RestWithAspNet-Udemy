using System.Collections.Generic;
using RestfulAspNetCore.Application.Model;

namespace RestfulAspNetCore.Application.Interfaces
{
    public interface IBookAppService
    {
        BookModel Create(BookModel book);
        BookModel FindById(string id);
        List<BookModel> FindAll();
        BookModel Update(BookModel book);
        void Delete(string id);
    }
}
