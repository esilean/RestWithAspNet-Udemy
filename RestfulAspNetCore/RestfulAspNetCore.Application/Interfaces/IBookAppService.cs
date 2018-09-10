using System;
using System.Collections.Generic;
using RestfulAspNetCore.Application.Model;

namespace RestfulAspNetCore.Application.Interfaces
{
    public interface IBookAppService : IDisposable
    {
        BookModel Add(BookModel book);
        BookModel FindById(int id);
        List<BookModel> FindAll();
        BookModel Update(BookModel book);
        void Remove(int id);
    }
}
