using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using XpressR.Server.Models;
using XpressR.Shared;
using Microsoft.EntityFrameworkCore;
using System.Data.Common;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace XpressR.Server.Controllers
{
    // Route will be api/User
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        MyContext _context;
        public UserController(MyContext context) 
        { 
            _context = context;
        }
        // GET: api/<UserController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            User? user = _context.Users.Include(u=>u.Properties).Include(u=>u.Bookings).ThenInclude(b=>b.Property).FirstOrDefault(record => record.UserId == id);
            if (user != null) return Ok(user);
            return BadRequest();
        }

        // POST api/<UserController>
        [HttpPost]
        public ActionResult<User> Post([FromBody] LoginUser loginInfo)
        {
            if (ModelState.IsValid)
            {
                User? userInDb = _context.Users.FirstOrDefault(record=>record.Email==loginInfo.Email);
                if (userInDb == null) return NotFound("Invalid Information");
                PasswordHasher<LoginUser> hasher = new PasswordHasher<LoginUser>();
                var result = hasher.VerifyHashedPassword(loginInfo, userInDb.Password, loginInfo.Password); // Result can be compared to 0 for failure        
                if (result == 0) return NotFound("Invalid Information");
                return Ok(userInDb);
            }
            return NotFound("Invalid Information");
        }

        // POST api/<UserController>/new
        [HttpPost("new")]
        public ActionResult<User> Register([FromBody] User newUser)
        {
            if (ModelState.IsValid)
            {
                if (!_context.Users.Any(record => record.Email == newUser.Email))
                {
                    PasswordHasher<User> Hasher = new PasswordHasher<User>();
                    // Updating our newUser's password to a hashed version         
                    newUser.Password = Hasher.HashPassword(newUser, newUser.Password);
                    _context.Add(newUser);
                    _context.SaveChanges();
                    return Ok(newUser);
                }
                else
                {
                    return BadRequest("Email");
                }
            }
            return NotFound("Invalid Information");
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
