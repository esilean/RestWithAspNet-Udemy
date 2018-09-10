using System;
using System.Collections.Generic;
using RestfulAspNetCore.Domain.Entities;
using RestfulAspNetCore.Domain.Interfaces;
using RestfulAspNetCore.Domain.InterfacesRepo;

namespace RestfulAspNetCore.Domain.Services
{
    public class BookService : IBookService
    {

        IBookRepo _bookRepo;

        public BookService(IBookRepo bookRepo)
        {
            _bookRepo = bookRepo;
        }

        public Book Create(Book book)
        {
            return _bookRepo.Create(book);
        }

        public void Delete(string id)
        {
            _bookRepo.Delete(id);
        }

        public List<Book> FindAll()
        {
            return _bookRepo.FindAll();
        }

        public Book FindById(string id)
        {
            return _bookRepo.FindById(id);
        }

        public Book Update(Book book)
        {
            return _bookRepo.Update(book);
        }
    }
}
