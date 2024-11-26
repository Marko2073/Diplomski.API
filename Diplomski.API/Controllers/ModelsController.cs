using Diplomski.Application.Dto.Searches;
using Diplomski.Application.UseCases.Queries;
using Diplomski.Implementation;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Diplomski.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ModelsController : ControllerBase
    {


        private UseCaseHandler _handler;
        public ModelsController(UseCaseHandler handler)
        {
            _handler = handler;
        }


        [HttpGet]
        public IActionResult Get([FromQuery] BaseSearch search, [FromServices] IGetModelsQuery query)
        {
            return Ok(_handler.HandleQuery(query, search));
        }

        // GET api/<ModelsController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ModelsController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ModelsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ModelsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
