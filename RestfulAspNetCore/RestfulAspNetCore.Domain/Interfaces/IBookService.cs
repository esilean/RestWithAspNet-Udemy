using System;
using System.Collections.Generic;
using RestfulAspNetCore.Domain.Entities;

namespace RestfulAspNetCore.Domain.Interfaces
{
    public interface IBookService : IDisposable
    {
        Book Add(Book book);
        Book FindById(int id);
        List<Book> FindAll();
        Book Update(Book book);
        void Remove(int id);
    }
}
