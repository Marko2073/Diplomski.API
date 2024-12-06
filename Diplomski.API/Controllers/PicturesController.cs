using Diplomski.Application.Dto.Searches;
using Diplomski.Application.UseCases.Queries.Pictures;
using Diplomski.Application.UseCases.Queries.Role;
using Diplomski.Implementation;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Diplomski.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PicturesController : ControllerBase
    {
        private UseCaseHandler _handler;
        public PicturesController(UseCaseHandler handler)
        {
            _handler = handler;
        }

        // GET: api/<PicturesController>
        [HttpGet]
        public IActionResult Get([FromQuery] BaseSearch search, [FromServices] IGetPicturesQuery query)
        {
            return Ok(_handler.HandleQuery(query, search));

        }

        // GET api/<PicturesController>/5
        [HttpGet("{id}")]

        public IActionResult Get(int id, [FromServices] IGetOnePictureQuery query)
        {
            return Ok(_handler.HandleQuery(query, id));
        }

        // POST api/<PicturesController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<PicturesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<PicturesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
