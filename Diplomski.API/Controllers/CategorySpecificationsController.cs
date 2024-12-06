using Diplomski.Application.Dto.Creates;
using Diplomski.Application.Dto.Searches;
using Diplomski.Application.Dto.Updates;
using Diplomski.Application.UseCases.Commands.Category;
using Diplomski.Application.UseCases.Commands.CategorySpecification;
using Diplomski.Application.UseCases.Commands.Model;
using Diplomski.Application.UseCases.Queries.CategorySpecification;
using Diplomski.Application.UseCases.Queries.Model;
using Diplomski.Implementation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Diplomski.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategorySpecificationsController : ControllerBase
    {
        private UseCaseHandler _handler;
        public CategorySpecificationsController(UseCaseHandler handler)
        {
            _handler = handler;
        }


        [HttpGet]
        public IActionResult Get([FromQuery] BaseSearch search, [FromServices] IGetCategorySpecificationsQuery query)
        {
            return Ok(_handler.HandleQuery(query, search));
        }

        // GET api/<CategorySpecificationsController>/5
        [HttpGet]
        [Route("{id}")]
        public IActionResult Get(int id, [FromServices] IGetOneCategorySpecificationQuery query)
        {
            return Ok(_handler.HandleQuery(query, id));
        }

        // POST api/<CategorySpecificationsController>
        [HttpPost]
        //[Authorize]
        public IActionResult Post([FromBody] CreateCategorySpecificationDto dto, [FromServices] ICreateCategorySpecificationCommand command)
        {
            _handler.HandleCommand(command, dto);
            return StatusCode(201);



        }

        // PUT api/<CategorySpecificationsController>/5
        [HttpPut("{id}")]
        //[Authorize]
        public IActionResult Put(int id, [FromBody] UpdateCategorySpecificationDto dto, [FromServices] IUpdateCategorySpecificationCommand command)
        {
            dto.Id = id;
            _handler.HandleCommand(command, dto);
            return StatusCode(204);

        }

        // DELETE api/<CategorySpecificationsController>/5
        [HttpDelete("{id}")]
        //[Authorize]
        public IActionResult Delete(int id, [FromServices] IDeleteCategorySpecificationCommand command)
        {
            _handler.HandleCommand(command, id);
            return StatusCode(204);

        }
    }
}
