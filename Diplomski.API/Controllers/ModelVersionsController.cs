using Diplomski.Application.Dto.Creates;
using Diplomski.Application.Dto.Searches;
using Diplomski.Application.UseCases.Commands.Model;
using Diplomski.Application.UseCases.Commands.ModelVersion;
using Diplomski.Application.UseCases.Queries.Brand;
using Diplomski.Application.UseCases.Queries.Model;
using Diplomski.Application.UseCases.Queries.ModelVersion;
using Diplomski.Implementation;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Diplomski.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ModelVersionsController : ControllerBase
    {
        
        private UseCaseHandler _handler;
        public ModelVersionsController(UseCaseHandler handler)
        {
            _handler = handler;
        }


        // GET: api/<ModelVersionsController>
        [HttpGet]
        public IActionResult Get([FromQuery] BaseSearch search, [FromServices] IGetModelVersionsQuery query)
        {
            return Ok(_handler.HandleQuery(query, search));
        }

        // GET api/<ModelVersionsController>/5
        [HttpGet]
        [Route("{id}")]
        public IActionResult Get(int id, [FromServices] IGetOneModelVersionQuery query)
        {
            return Ok(_handler.HandleQuery(query, id));
        }

        // POST api/<ModelVersionsController>
        [HttpPost]
        //[Authorize]
        public IActionResult Post([FromBody] CreateModelVersionDto dto, [FromServices] ICreateModelVersionCommand command)
        {
            _handler.HandleCommand(command, dto);
            return StatusCode(201);



        }

        // PUT api/<ModelVersionsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ModelVersionsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
