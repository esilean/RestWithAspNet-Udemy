﻿using System;
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
    public class PersonController : Controller
    {

        private IPersonAppService _personAppService;

        public PersonController(IPersonAppService personAppService)
        {
            _personAppService = personAppService;
        }

        // GET: api/values
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_personAppService.FindAll());
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
            var person = _personAppService.FindById(id);
            if (person == null)
                return NotFound();

            return Ok(person);
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody]PersonModel person)
        {
            if (person == null)
                return BadRequest();
                
            return new ObjectResult(_personAppService.Create(person));
        }

        // PUT api/values/5
        [HttpPut]
        public IActionResult Put([FromBody]PersonModel person)
        {
            if (person == null)
                return BadRequest();

            return new ObjectResult(_personAppService.Update(person));
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            _personAppService.Delete(id);
            return NoContent();
        }
    }
}
