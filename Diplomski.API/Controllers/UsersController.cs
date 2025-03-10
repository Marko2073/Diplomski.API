﻿using Diplomski.Application.Dto.Creates;
using Diplomski.Application.Dto.Searches;
using Diplomski.Application.Dto.Updates;
using Diplomski.Application.UseCases.Commands.Brand;
using Diplomski.Application.UseCases.Commands.Role;
using Diplomski.Application.UseCases.Commands.User;
using Diplomski.Application.UseCases.Queries.User;
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
        public IActionResult Get([FromQuery] BaseSearch search, [FromServices] IGetUsersQuery query)
        {
            return Ok(_handler.HandleQuery(query, search));
        }

        // GET api/<UsersController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id, [FromServices] IGetOneUserQuery query)
        {
            return Ok(_handler.HandleQuery(query, id));
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
        //[Authorize]
        [Consumes("multipart/form-data")]

        public IActionResult Put(int id, [FromForm] UpdateUserDto dto, [FromServices] IUpdateUserCommand command)
        {
            dto.Id = id;
            _handler.HandleCommand(command, dto);

            return NoContent();
        }

        // DELETE api/<UsersController>/5
        [HttpDelete("{id}")]
        //[Authorize]
        public IActionResult Delete(int id, [FromServices] IDeleteUserCommand command)
        {
            _handler.HandleCommand(command, id);
            return StatusCode(204);

        }
    }
}
