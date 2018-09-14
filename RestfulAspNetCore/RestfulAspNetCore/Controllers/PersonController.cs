using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RestfulAspNetCore.Application.Interfaces;
using RestfulAspNetCore.Application.Model;
using RestfulAspNetCore.Application.Model.Pagination;
using RestfulAspNetCore.Services.PaginationConfig;
using RestfulAspNetCore.Services.PaginationConfig.PersonPage;
using System.Collections.Generic;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RestfulAspNetCore.Services.Controllers
{
    [ApiVersion("1")]
    [Route("api/[controller]/v{version:apiVersion}")]
    [ApiController]
    public class PersonController : Controller
    {

        private readonly IPersonAppService _personAppService;
        private readonly IUrlHelper _urlHelper;

        public PersonController(IPersonAppService personAppService, IUrlHelper urlHelper)
        {
            _personAppService = personAppService;
            _urlHelper = urlHelper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(List<PersonModel>))]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [Authorize]
        public IActionResult Get()
        {
            var userIdent = User.Identity;


            return Ok(_personAppService.FindAll());
        }

        //[HttpGet("paging")]
        [HttpGet("paging")]
        [ProducesResponseType(200, Type = typeof(PersonPageModel))]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public IActionResult Paging([FromQuery] PagingParams pagingParams)
        {
            var persons = _personAppService.FindWithPageSearch(pagingParams);

            Response.Headers.Add("X-Pagination", persons.GetHeader().ToJson());

            var personPageModel = new PersonPageModel
            {
                Paging = persons.GetHeader(),
                Links = PageLink<PersonModel>.GetLinks(_urlHelper, "paging", persons),
                Items = persons.List
            };
            return Ok(personPageModel);
        }

        [HttpGet("findbyname")]
        [ProducesResponseType(200, Type = typeof(List<PersonModel>))]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public IActionResult GetByName([FromQuery] string firstName, [FromQuery] string lastName)
        {
            return Ok(_personAppService.FindByName(firstName, lastName));
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

        [HttpPatch]
        [ProducesResponseType(200, Type = typeof(PersonModel))]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public IActionResult Patch([FromBody]PersonModel person)
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
