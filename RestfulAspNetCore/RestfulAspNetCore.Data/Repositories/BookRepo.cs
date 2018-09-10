using System;
using System.Collections.Generic;
using System.Linq;
using RestfulAspNetCore.Data.Context;
using RestfulAspNetCore.Domain.Entities;
using RestfulAspNetCore.Domain.InterfacesRepo;

namespace RestfulAspNetCore.Data.Repositories
{
    public class BookRepo : IBookRepo
    {

        private ContextApp _context;

        public BookRepo(ContextApp context)
        {
            _context = context;
        }

        public Book Create(Book book)
        {
            try
            {
                _context.Add(book);
                _context.SaveChanges();

                return book;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Delete(string id)
        {
            _context.Remove(FindById(id));
            _context.SaveChanges();
        }

        public List<Book> FindAll()
        {
            return _context.Books.ToList();
        }

        public Book FindById(string id)
        {
            return _context.Books.Find(id);
        }

        public Book Update(Book book)
        {

            var result = FindById(book.Id);

            if (result == null)
                return new Book();

            try
            {
                _context.Entry(result).CurrentValues.SetValues(book);
                _context.SaveChanges();

                return book;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
