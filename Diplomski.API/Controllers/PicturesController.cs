using Diplomski.Application.Dto.Creates;
using Diplomski.Application.Dto.Searches;
using Diplomski.Application.Dto.Updates;
using Diplomski.Application.UseCases.Commands.Pictures;
using Diplomski.Application.UseCases.Commands.Role;
using Diplomski.Application.UseCases.Queries.Pictures;
using Diplomski.Application.UseCases.Queries.Role;
using Diplomski.Implementation;
using Microsoft.AspNetCore.Authorization;
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
        //[Authorize]
        [Consumes("multipart/form-data")]
        public IActionResult Post([FromForm] CreatePictureDto dto, [FromServices] ICreatePictureCommand command)
        {
            _handler.HandleCommand(command, dto);
            return StatusCode(201);
        }

        // PUT api/<PicturesController>/5
        [HttpPut("{id}")]
        [Consumes("multipart/form-data")]
        //[Authorize]
        public IActionResult Put(int id, [FromForm] UpdatePictureDto dto, [FromServices] IUpdatePictureCommand command)
        {
            dto.Id = id;
            _handler.HandleCommand(command, dto);
            return StatusCode(201);
        }

        // DELETE api/<PicturesController>/5
        [HttpDelete("{id}")]
        //[Authorize]
        public IActionResult Delete(int id, [FromServices] IDeletePictureCommand command)
        {
            _handler.HandleCommand(command, id);
            return StatusCode(204);

        }
    }
}
