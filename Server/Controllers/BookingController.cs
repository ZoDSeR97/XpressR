using Microsoft.AspNetCore.Mvc;
using XpressR.Server.Models;
using XpressR.Shared;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace XpressR.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        MyContext _context;
        public BookingController(MyContext context)
        {
            _context = context;
        }
        // GET: api/<BookingController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<BookingController>/5
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            RSVP? info = _context.RSVP.FirstOrDefault(r => r.RSVPId == id);
            if (info != null) return Ok(info);
            return BadRequest();
        }

        // POST api/<BookingController>/new
        [HttpPost("new")]
        public ActionResult Post([FromBody] RSVP info)
        {
            if (ModelState.IsValid)
            {
                _context.Add(info);
                _context.SaveChanges();
                return Ok(info);
            }
            return BadRequest();
        }

        // PUT api/<BookingController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<BookingController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            RSVP? booking = _context.RSVP.FirstOrDefault(record=>record.RSVPId== id);
            if (booking != null)
            {
                _context.Remove(booking);
                _context.SaveChanges();
                return Ok();
            }
            return BadRequest();
        }
    }
}
