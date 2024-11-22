using Diplomski.Application.Dto.Creates;
using Diplomski.Application.Dto.Searches;
using Diplomski.Application.UseCases.Commands;
using Diplomski.Application.UseCases.Queries;
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
            return Ok(_handler.HandleQuery(query, new IdSearch { Id = id }));
        }

        [HttpPost]
        [Authorize]
        public IActionResult Post([FromBody] CreateBrandDto dto, [FromServices] ICreateBrandCommand command)
        {
            _handler.HandleCommand(command, dto);
            return StatusCode(201);



        }
    }
}
