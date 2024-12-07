using Diplomski.Application.Dto.Creates;
using Diplomski.Application.Dto.Searches;
using Diplomski.Application.Dto.Updates;
using Diplomski.Application.UseCases.Commands.ModelVersionSpecification;
using Diplomski.Application.UseCases.Commands.Price;
using Diplomski.Application.UseCases.Commands.Role;
using Diplomski.Application.UseCases.Queries.Brand;
using Diplomski.Application.UseCases.Queries.CategorySpecification;
using Diplomski.Application.UseCases.Queries.Price;
using Diplomski.Implementation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Diplomski.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PricesController : ControllerBase
    {
        private UseCaseHandler _handler;
        public PricesController(UseCaseHandler handler)
        {
            _handler = handler;
        }


        [HttpGet]
        public IActionResult Get([FromQuery] PriceSearch search, [FromServices] IGetPricesQuery query)
        {
            return Ok(_handler.HandleQuery(query, search));
        }

        // GET api/<PricesController>/5
        [HttpGet]
        [Route("{id}")]
        public IActionResult Get(int id, [FromServices] IGetOnePriceQuery query)
        {
            return Ok(_handler.HandleQuery(query, id));
        }

        // POST api/<PricesController>
        [HttpPost]
        //[Authorize]
        public IActionResult Post([FromBody] CreatePriceDto dto, [FromServices] ICreatePriceCommand command)
        {
            _handler.HandleCommand(command, dto);
            return StatusCode(201);



        }

        // PUT api/<PricesController>/5
        [HttpPut("{id}")]
        //[Authorize]
        public IActionResult Put(int id, [FromBody] UpdatePriceDto dto, [FromServices] IUpdatePriceCommand command)
        {
            dto.Id = id;
            _handler.HandleCommand(command, dto);
            return StatusCode(204);

        }

        // DELETE api/<PricesController>/5
        [HttpDelete("{id}")]
        //[Authorize]
        public IActionResult Delete(int id, [FromServices] IDeletePriceCommand command)
        {
            _handler.HandleCommand(command, id);
            return StatusCode(204);

        }
    }
}
