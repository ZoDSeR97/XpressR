using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using XpressR.Server.Models;
using XpressR.Shared;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace XpressR.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PropertyController : ControllerBase
    {
        MyContext _context;
        public PropertyController(MyContext context) 
        {
            _context = context;
        }
        // GET: api/<PropertyController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/<PropertyController>/all
        [HttpGet("all")]
        public ActionResult GetAll()
        {
            return Ok(_context.Properties.ToList());
        }

        // GET api/<PropertyController>/5
        [HttpGet("{id}")]
        public ActionResult<Property> Get(int id)
        {
            Property? p = _context.Properties.Include(p=>p.Owner).FirstOrDefault(p => p.PropertyId == id);
            string json = JsonConvert.SerializeObject(p, Formatting.Indented, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
            if (p!=null) return Ok(json);
            return BadRequest();
        }

        // POST api/<PropertyController>/new
        [HttpPost("new")]
        public ActionResult Post([FromBody] Property NewProp)
        {
            if (ModelState.IsValid)
            {
                _context.Add(NewProp);
                _context.SaveChanges();
                return Ok(NewProp);
            }
            return BadRequest();
        }

        // PUT api/<PropertyController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<PropertyController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
