using System;
using System.Collections.Generic;
using System.Threading;
using AutoMapper;
using RestfulAspNetCore.Application.Interfaces;
using RestfulAspNetCore.Application.Model;
using RestfulAspNetCore.Domain.Entities;
using RestfulAspNetCore.Domain.Interfaces;
using RestfulAspNetCore.Domain.InterfacesRepo;
using RestfulAspNetCore.Domain.Services;

namespace RestfulAspNetCore.Application.Services
{
    public class BookAppService : AppService, IBookAppService
    {

        private readonly IMapper _mapper;
        private readonly IBookService _bookService;

        public BookAppService(IMapper mapper, IBookService bookService, IUnitOfWork uow) : base(uow)
        {
            _bookService = bookService;
            _mapper = mapper;
        }

        public BookModel Add(BookModel book)
        {
            var b = _mapper.Map<Book>(book);
            _bookService.Add(b);

            Commit();

            return _mapper.Map<BookModel>(b);
        }

        public void Remove(int id)
        {
            _bookService.Remove(id);
            Commit();
        }

        public List<BookModel> FindAll()
        {
            var books = _bookService.FindAll();

            return _mapper.Map<List<BookModel>>(books);
        }

        public BookModel FindById(int id)
        {
            var book = _bookService.FindById(id);
            return _mapper.Map<BookModel>(book);
        }

        public BookModel Update(BookModel book)
        {
            var p = _mapper.Map<Book>(book);
            _bookService.Update(p);
            Commit();
            return _mapper.Map<BookModel>(p);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
