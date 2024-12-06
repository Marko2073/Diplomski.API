using Diplomski.Application.Dto.Creates;
using Diplomski.Application.Dto.Searches;
using Diplomski.Application.Dto.Updates;
using Diplomski.Application.UseCases.Commands.Brand;
using Diplomski.Application.UseCases.Commands.Role;
using Diplomski.Application.UseCases.Queries.Role;
using Diplomski.Application.UseCases.Queries.Specification;
using Diplomski.Implementation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Diplomski.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        private UseCaseHandler _handler;
        public RolesController(UseCaseHandler handler)
        {
            _handler = handler;
        }


        [HttpGet]
        public IActionResult Get([FromQuery] BaseSearch search, [FromServices] IGetRolesQuery query)
        {
            return Ok(_handler.HandleQuery(query, search));
        }

        // GET api/<RolesController>/5
        [HttpGet("{id}")]
        
        public IActionResult Get(int id, [FromServices] IGetOneRoleQuery query)
        {
            return Ok(_handler.HandleQuery(query, id));
        }

        [HttpPost]
        //[Authorize]
        public IActionResult Post([FromBody] CreateRoleDto dto, [FromServices] ICreateRoleCommand command)
        {
            _handler.HandleCommand(command, dto);
            return StatusCode(201);
        }
        // PUT api/<RolesController>/5
        [HttpPut("{id}")]
        [Authorize]
        public IActionResult Put(int id, [FromBody] UpdateRoleDto dto, [FromServices] IUpdateRoleCommand command)
        {
            dto.Id = id;
            _handler.HandleCommand(command, dto);
            return StatusCode(204);

        }


        // DELETE api/<RolesController>/5
        [HttpDelete("{id}")]
        //[Authorize]
        public IActionResult Delete(int id, [FromServices] IDeleteRoleCommand command)
        {
            _handler.HandleCommand(command, id);
            return StatusCode(204);

        }
    }
}
