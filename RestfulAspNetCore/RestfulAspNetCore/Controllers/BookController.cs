using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RestfulAspNetCore.Application.Interfaces;
using RestfulAspNetCore.Application.Model;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RestfulAspNetCore.Services.Controllers
{
    [ApiVersion("1")]
    [Route("api/[controller]/v{version:apiVersion}")]
    [ApiController]
    public class BookController : Controller
    {
        private IBookAppService _bookAppService;

        public BookController(IBookAppService bookAppService)
        {
            _bookAppService = bookAppService;
        }

        // GET: api/values
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_bookAppService.FindAll());
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var book = _bookAppService.FindById(id);
            if (book == null)
                return NotFound();

            return Ok(book);
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody]BookModel book)
        {
            return new ObjectResult(_bookAppService.Add(book));
        }

        // PUT api/values/5
        [HttpPut]
        public IActionResult Put([FromBody]BookModel book)
        {
            return new ObjectResult(_bookAppService.Update(book));
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _bookAppService.Remove(id);
            return NoContent();
        }
    }
}
