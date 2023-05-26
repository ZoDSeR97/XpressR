using Microsoft.AspNetCore.Mvc;
using Stripe;
using Stripe.Checkout;
using XpressR.Server.Models;
using XpressR.Shared;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace XpressR.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        MyContext _context;
        public PaymentController(MyContext context)
        {
            _context = context;
            StripeConfiguration.ApiKey = "sk_test_51MrCR6FLmaU0LZ7leyJZocCMPegVxdXn2wJKFg39AXlmB7YRoBxPKjais6NYPgz4R0QMSDBBMW4Du3mP1Ho4LJqk00rSvFqZxr";
        }

        [HttpPost("create-checkout-session")]
        public ActionResult CreateCheckoutSession(RSVP reservation)
        {
            Property? p = _context.Properties.FirstOrDefault(p => p.PropertyId == reservation.PropertyId);
            if (p != null)
            {
                var options = new SessionCreateOptions
                {
                    PaymentMethodTypes = new List<string> { "card"  },
                    LineItems = new List<SessionLineItemOptions>
                    {
                      new SessionLineItemOptions
                      {
                        PriceData = new SessionLineItemPriceDataOptions
                        {
                          UnitAmount = p.Price*(int)(reservation.CheckOut-reservation.CheckIn).TotalDays,
                          Currency = "usd",
                          ProductData = new SessionLineItemPriceDataProductDataOptions
                          {
                            Name = p.Name,
                            Images = new List<string> {p.Thumbnail??""}
                          },
                        },
                        Quantity = (long)(reservation.CheckOut-reservation.CheckIn).TotalDays,
                      },
                    },
                    Mode = "payment",
                    SuccessUrl = "http://localhost:5080/success",
                    CancelUrl = "http://localhost:5080/",
                };
                var service = new SessionService();
                Session session = service.Create(options);

                return Ok(session.Url);
            }

            return new StatusCodeResult(303);
        }

        // GET: api/<PaymentController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<PaymentController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<PaymentController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<PaymentController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<PaymentController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
