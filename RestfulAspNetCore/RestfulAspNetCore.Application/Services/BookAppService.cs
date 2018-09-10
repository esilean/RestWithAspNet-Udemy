using System;
using System.Collections.Generic;
using System.Threading;
using AutoMapper;
using RestfulAspNetCore.Application.Interfaces;
using RestfulAspNetCore.Application.Model;
using RestfulAspNetCore.Domain.Entities;
using RestfulAspNetCore.Domain.Interfaces;
using RestfulAspNetCore.Domain.Services;

namespace RestfulAspNetCore.Application.Services
{
    public class BookAppService : IBookAppService
    {

        private readonly IMapper _mapper;
        private IBookService _bookService;

        public BookAppService(IMapper mapper, IBookService bookService)
        {
            _bookService = bookService;
            _mapper = mapper;
        }

        public BookModel Create(BookModel book)
        {
            var b = _mapper.Map<Book>(book);
            _bookService.Create(b);

            return _mapper.Map<BookModel>(b);
        }

        public void Delete(string id)
        {
            _bookService.Delete(id);
        }

        public List<BookModel> FindAll()
        {

            var persons = _bookService.FindAll();

            return _mapper.Map<List<BookModel>>(persons);

        }

        public BookModel FindById(string id)
        {
            var book = _bookService.FindById(id);
            return _mapper.Map<BookModel>(book);
        }

        public BookModel Update(BookModel book)
        {
            var p = _mapper.Map<Book>(book);
            _bookService.Update(p);
            return _mapper.Map<BookModel>(p);
        }

    }
}
