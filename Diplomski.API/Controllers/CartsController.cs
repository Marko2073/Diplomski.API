using Diplomski.Application.Dto.Searches;
using Diplomski.Application.UseCases.Queries.Brand;
using Diplomski.Application.UseCases.Queries.Cart;
using Diplomski.Implementation;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Diplomski.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartsController : ControllerBase
    {
        private UseCaseHandler _handler;
        public CartsController(UseCaseHandler handler)
        {
            _handler = handler;
        }


        // GET: api/<BrandsController>
        [HttpGet]
        public IActionResult Get([FromQuery] BaseSearch search, [FromServices] IGetCartsQuery query)
        {
            return Ok(_handler.HandleQuery(query, search));
        }

        // GET api/<CartsController>/5
        [HttpGet]
        [Route("{id}")]
        public IActionResult Get(int id, [FromServices] IGetOneCartQuery query)
        {
            return Ok(_handler.HandleQuery(query, id));
        }

        // POST api/<CartsController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<CartsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CartsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
