using Diplomski.Application.Dto.Creates;
using Diplomski.Application.Dto.Searches;
using Diplomski.Application.UseCases.Commands.Brand;
using Diplomski.Application.UseCases.Commands.Configuration;
using Diplomski.Application.UseCases.Queries.Brand;
using Diplomski.Application.UseCases.Queries.Configuration;
using Diplomski.Implementation;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Diplomski.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConfigurationsController : ControllerBase
    {
        private UseCaseHandler _handler;
        public ConfigurationsController(UseCaseHandler handler)
        {
            _handler = handler;
        }


        // GET: api/<BrandsController>
        [HttpGet]
        public IActionResult Get([FromQuery] BaseSearch search, [FromServices] IGetConfigurationsQuery query)
        {
            return Ok(_handler.HandleQuery(query, search));
        }

        // GET api/<ConfigurationsController>/5
        [HttpGet]
        [Route("{id}")]
        public IActionResult Get(int id, [FromServices] IGetOneConfigurationQuery query)
        {
            return Ok(_handler.HandleQuery(query, id));
        }

        [HttpPost]
        //[Authorize]
        public IActionResult Post([FromBody] CreateConfigurationDto dto, [FromServices] ICreateConfigurationCommand command)
        {
            _handler.HandleCommand(command, dto);
            return StatusCode(201);



        }
        // PUT api/<ConfigurationsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ConfigurationsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
