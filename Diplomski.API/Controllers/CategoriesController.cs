using Diplomski.Application.Dto.Creates;
using Diplomski.Application.Dto.Searches;
using Diplomski.Application.Dto.Updates;
using Diplomski.Application.UseCases.Commands.Brand;
using Diplomski.Application.UseCases.Commands.Category;
using Diplomski.Application.UseCases.Queries.Category;
using Diplomski.Implementation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Diplomski.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private UseCaseHandler _handler;
        public CategoriesController(UseCaseHandler handler)
        {
            _handler = handler;
        }


        [HttpGet]
        public IActionResult Get([FromQuery] BaseSearch search, [FromServices] IGetCategoriesQuery query)
        {
            return Ok(_handler.HandleQuery(query, search));
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult Get(int id, [FromServices] IGetOneCategoryQuery query)
        {
            return Ok(_handler.HandleQuery(query, id));
        }

        // POST api/<CategoriesController>
        [HttpPost]
        //[Authorize]
        public IActionResult Post([FromBody] CreateCategoryDto dto, [FromServices] ICreateCategoryCommand command)
        {
            _handler.HandleCommand(command, dto);
            return StatusCode(201);



        }

        // PUT api/<CategoriesController>/5
        [HttpPut("{id}")]
        [Authorize]
        public IActionResult Put(int id, [FromBody] UpdateCategoryDto dto, [FromServices] IUpdateCategoryCommand command)
        {
            dto.Id = id;
            _handler.HandleCommand(command, dto);
            return StatusCode(204);

        }

        // DELETE api/<CategoriesController>/5
        [HttpDelete("{id}")]
        //[Authorize]
        public IActionResult Delete(int id, [FromServices] IDeleteCategoryCommand command)
        {
            _handler.HandleCommand(command, id);
            return StatusCode(204);

        }
    }
}
