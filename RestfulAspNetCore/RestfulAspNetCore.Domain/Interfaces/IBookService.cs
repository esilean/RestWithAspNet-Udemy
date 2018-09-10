using System;
using System.Collections.Generic;
using RestfulAspNetCore.Domain.Entities;

namespace RestfulAspNetCore.Domain.Interfaces
{
    public interface IBookService
    {
        Book Create(Book book);
        Book FindById(string id);
        List<Book> FindAll();
        Book Update(Book book);
        void Delete(string id);
    }
}
