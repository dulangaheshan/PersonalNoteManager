/**
 * @author [D.5haN]
 * @email [dulangah2@gmail.com]
 * @create date 2021-01-09 17:33:40
 * @modify date 2021-01-09 17:33:40
 * @desc [Api end points for user]
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CordFortPersonalNoteManager.Contracts;
using CordFortPersonalNoteManager.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CordFortPersonalNoteManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        // GET: api/User
        private IRepositoryWrapper _repository;
        private IMapper _mapper;
        public UserController(IRepositoryWrapper repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult GetAllUsers()
        {
            try
            {
                var owners = _repository.User.GetAllUsers();
                return Ok(owners);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }

    // GET: api/User/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/User
        [HttpPost]
        public IActionResult CreateNote([FromBody]User user)
        {
            try
            {
                if (user == null)
                {
                    return BadRequest("User object is null");
                }
                if (!ModelState.IsValid)
                {
                    return BadRequest("Invalid model object");
                }



                var UserEntity = _mapper.Map<User>(user);
                _repository.User.CreateUser(UserEntity);
                _repository.Save();
                var CreatedNote = _mapper.Map<User>(UserEntity);
                return Ok(UserEntity);
            }
            catch (Exception ex)
            {

                return StatusCode(500, "Internal server error");
            }
        }

        // PUT: api/User/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
