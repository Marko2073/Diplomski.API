using Diplomski.Application.Dto.Creates;
using Diplomski.Application.UseCases.Commands.Brand;
using Diplomski.Application.UseCases.Commands.User;
using Diplomski.Implementation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Diplomski.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private UseCaseHandler _handler;
        public UsersController(UseCaseHandler handler)
        {
            _handler = handler;
        }
        // GET: api/<UsersController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<UsersController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<UsersController>
        [HttpPost]
        public IActionResult Post([FromBody] RegisterUserDto dto, [FromServices] ICreateUserCommand command)
        {
            _handler.HandleCommand(command, dto);
            return StatusCode(201);



        }
        // PUT api/<UsersController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<UsersController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
