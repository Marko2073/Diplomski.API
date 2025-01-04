using Diplomski.Application.Dto.Searches;
using Diplomski.Application.UseCases.Queries.Model;
using Diplomski.Application.UseCases.Queries.Table;
using Diplomski.Implementation;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Diplomski.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TablesController : ControllerBase
    {
        private UseCaseHandler _handler;
        public TablesController(UseCaseHandler handler)
        {
            _handler = handler;
        }


        [HttpGet]
        public IActionResult Get([FromQuery] BaseSearch search, [FromServices] IGetTablesQuery query)
        {
            return Ok(_handler.HandleQuery(query, search));
        }


        // GET api/<TablesController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<TablesController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<TablesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<TablesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
