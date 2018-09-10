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

        public Book Add(Book book)
        {
            return _bookRepo.Add(book);
        }

        public void Remove(int id)
        {
            _bookRepo.Remove(id);
        }

        public List<Book> FindAll()
        {
            return _bookRepo.FindAll();
        }

        public Book FindById(int id)
        {
            return _bookRepo.FindById(id);
        }

        public Book Update(Book book)
        {
            return _bookRepo.Update(book);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
