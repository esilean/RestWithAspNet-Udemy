using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RestfulAspNetCore.Application.Interfaces;
using RestfulAspNetCore.Application.Model;
using System.Collections.Generic;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RestfulAspNetCore.Services.Controllers
{
    [ApiVersion("1")]
    [Route("api/[controller]/v{version:apiVersion}")]
    [ApiController]
    public class PersonController : Controller
    {

        private IPersonAppService _personAppService;

        public PersonController(IPersonAppService personAppService)
        {
            _personAppService = personAppService;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(List<PersonModel>))]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [Authorize]
        public IActionResult Get()
        {
            return Ok(_personAppService.FindAll());
        }

        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(PersonModel))]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public IActionResult Get(int id)
        {
            var person = _personAppService.FindById(id);

            if (person == null)
                return NotFound();

            return Ok(person);
        }

        [HttpPost]
        [ProducesResponseType(200, Type = typeof(PersonModel))]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public IActionResult Post([FromBody]PersonModel person)
        {
            return new ObjectResult(_personAppService.Add(person));
        }

        [HttpPut]
        [ProducesResponseType(200, Type = typeof(PersonModel))]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public IActionResult Put([FromBody]PersonModel person)
        {
            return new ObjectResult(_personAppService.Update(person));
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public IActionResult Delete(int id)
        {
            _personAppService.Remove(id);
            return NoContent();
        }
    }
}
