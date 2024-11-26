using Diplomski.Application.Dto.Creates;
using Diplomski.Application.Dto.Delete;
using Diplomski.Application.Dto.Searches;
using Diplomski.Application.Dto.Updates;
using Diplomski.Application.UseCases.Commands.Brand;
using Diplomski.Application.UseCases.Queries.Brand;
using Diplomski.Implementation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Diplomski.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsController : ControllerBase
    {
        private UseCaseHandler _handler;
        public BrandsController(UseCaseHandler handler)
        {
            _handler = handler;
        }


        // GET: api/<BrandsController>
        [HttpGet]
        public IActionResult Get([FromQuery] BaseSearch search, [FromServices] IGetBrandsQuery query)
        {
            return Ok(_handler.HandleQuery(query, search));
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult Get(int id, [FromServices] IGetOneBrandQuery query)
        {
            return Ok(_handler.HandleQuery(query, id));
        }

        [HttpPost]
        [Authorize]
        public IActionResult Post([FromBody] CreateBrandDto dto, [FromServices] ICreateBrandCommand command)
        {
            _handler.HandleCommand(command, dto);
            return StatusCode(201);



        }
        // PUT api/<BrandsController>/5
        [HttpPut("{id}")]
        [Authorize]
        public IActionResult Put(int id, [FromBody] UpdateBrandDto dto, [FromServices] IUpdateBrandCommand command)
        {
            dto.Id = id;
            _handler.HandleCommand(command, dto);
            return StatusCode(204);

        }

        // DELETE api/<BrandsController>/5
        [HttpDelete("{id}")]
        //[Authorize]
        public IActionResult Delete(int id, [FromServices] IDeleteBrandCommand command)
        {
            _handler.HandleCommand(command, id);
            return StatusCode(204);

        }
    }
}
