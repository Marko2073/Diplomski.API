using Diplomski.Application.UseCases.Queries.Brand;
using Diplomski.Application.UseCases.Queries.Column;
using Diplomski.Implementation;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Diplomski.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ColumnsController : ControllerBase
    {
        private UseCaseHandler _handler;
        public ColumnsController(UseCaseHandler handler)
        {
            _handler = handler;
        }

       
        [HttpGet("{table}")]
        public IActionResult Get(string table, [FromServices] IGetColumnsQuery query)
        {
            return Ok(_handler.HandleQuery(query, table));
        }


        // POST api/<ColumnsController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ColumnsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ColumnsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
