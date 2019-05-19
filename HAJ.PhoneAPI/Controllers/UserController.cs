using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HAJ.PhoneAPI.Domain;
using HAJ.PhoneAPI.Entities;
using HAJ.PhoneAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HAJ.PhoneAPI.Controllers
{
    // Authorisation must be done using the 'Authorization' header and then 'Bearer TOKEN'
    // Security could be improved with DTO Entities, but authorisation is required to access these methods anyway

    [Authorize]
    [Route("[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserService _userService;
        private IPhoneBookUsersRespository _phoneBookUsersRespository;

        public UserController(IUserService userService, IPhoneBookUsersRespository phoneBookUsersRespository)
        {
            _userService = userService;
            _phoneBookUsersRespository = phoneBookUsersRespository;
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody]User userParam)
        {
            var user = _userService.Authenticate(userParam.Username, userParam.Password);

            if (user == null)
                return BadRequest(new { message = "Username or password is incorrect" });

            return Ok(user);
        }

        // GET api/values
        [HttpPost]
        [Route("create")]
        public IActionResult Create([FromBody]PhoneBookUser newPhoneBookUser)
        {
            var result = _phoneBookUsersRespository.CreateUser(newPhoneBookUser);
            if (result != null)
            {
                return Ok(result);
            }

            return BadRequest("User was not created.");
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            var result = _phoneBookUsersRespository.ReadUser(id);
            if (result != null)
            {
                return Ok(result);
            }

            return BadRequest("User was not found or an error occurred.");
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]PhoneBookUser newPhoneBookUser)
        {
            var result = _phoneBookUsersRespository.UpdateUser(id, newPhoneBookUser);
            if (result)
            {
                return Ok(@"User {id} was updated successfully");
            }

            return BadRequest("User was not created.");
        }

        //DELETE api/values/5
        [HttpDelete("{id}")]
        public ActionResult<string> Delete(int id)
        {
            var result = _phoneBookUsersRespository.DeleteUser(id);
            if (result)
            {
                return Ok($"Deleted User {id} Successfully");
            }

            return BadRequest("User was not found or an error occurred.");
        }
    }
}
