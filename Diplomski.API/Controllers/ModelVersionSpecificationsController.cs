using Diplomski.Application.Dto.Creates;
using Diplomski.Application.Dto.Searches;
using Diplomski.Application.Dto.Updates;
using Diplomski.Application.UseCases.Commands.CategorySpecification;
using Diplomski.Application.UseCases.Commands.ModelVersion;
using Diplomski.Application.UseCases.Commands.ModelVersionSpecification;
using Diplomski.Application.UseCases.Queries.CategorySpecification;
using Diplomski.Application.UseCases.Queries.ModelVersion;
using Diplomski.Application.UseCases.Queries.ModelVersionSpecification;
using Diplomski.Implementation;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Diplomski.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ModelVersionSpecificationsController : ControllerBase
    {
        private UseCaseHandler _handler;
        public ModelVersionSpecificationsController(UseCaseHandler handler)
        {
            _handler = handler;
        }


        [HttpGet]
        public IActionResult Get([FromQuery] BaseSearch search, [FromServices] IGetModelVersionSpecificationsQuery query)
        {
            return Ok(_handler.HandleQuery(query, search));
        }

        // GET api/<ModelVersionSpecificationsController>/5
        [HttpGet]
        [Route("{id}")]
        public IActionResult Get(int id, [FromServices] IGetOneModelVersionSpecificationQuery query)
        {
            return Ok(_handler.HandleQuery(query, id));
        }

        // POST api/<ModelVersionSpecificationsController>
        [HttpPost]
        //[Authorize]
        public IActionResult Post([FromBody] CreateModelVersionSpecificationDto dto, [FromServices] ICreateModelVersionSpecificationCommand command)
        {
            _handler.HandleCommand(command, dto);
            return StatusCode(201);



        }

        // PUT api/<ModelVersionSpecificationsController>/5
        [HttpPut("{id}")]
        //[Authorize]
        public IActionResult Put(int id, [FromBody] UpdateModelVersionSpecificationDto dto, [FromServices] IUpdateModelVersionSpecificationCommand command)
        {
            dto.Id = id;
            _handler.HandleCommand(command, dto);
            return StatusCode(204);

        }

        // DELETE api/<ModelVersionSpecificationsController>/5
        [HttpDelete("{id}")]
        //[Authorize]
        public IActionResult Delete(int id, [FromServices] IDeleteModelVersionSpecificationCommand command)
        {
            _handler.HandleCommand(command, id);
            return StatusCode(204);

        }
    }
}
