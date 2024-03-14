using CustomerAPI.Domain;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CustomerAPI.Controllers
{
    [Route("api/customer")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        // GET: api/customer
        [HttpGet]
        public async Task<IEnumerable<Customer>> Get()
        {
            return null;
        }

        // GET api/customer/5
        [HttpGet("{id}")]
        public async Task<Customer> Get(int id)
        {
            return null;
        }

        // POST api/customer
        [HttpPost]
        public void Post([FromBody] List<Customer> customers)
        {
        }

        // PUT api/customer/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Customer customers)
        {
        }

        // DELETE api/customer/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
