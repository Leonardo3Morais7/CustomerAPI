using CustomerAPI.Application;
using CustomerAPI.Domain;
using CustomerAPI.Service;
using Microsoft.AspNetCore.Mvc;

namespace CustomerAPI.Controllers
{
    [Route("api/customer")]
    [ApiController]
    [Produces("application/json")]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;
        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        // GET: api/customer
        [HttpGet]
        public async Task<IEnumerable<Customer>> GetAll()
        {
            return await _customerService.GetAll();
        }

        // GET api/customer/{id}
        [HttpGet("{id}")]
        public async Task<Customer> Get(int id)
        {
            return await _customerService.Get(id);
        }

        // POST api/customer
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] List<Customer> customers)
        {
            var customersAdded = await _customerService.Add(customers);
            if(customersAdded.Any())
                return CreatedAtAction(nameof(GetAll), customersAdded);
            else
                return BadRequest("No valid customer was found in the list.");
        }

        // PUT api/customer/{id}
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] Customer customer)
        {
            if (await _customerService.Update(customer))
                return Ok("Customer updated.");
            else
                return NoContent();
        }

        // DELETE api/customer/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (await _customerService.Delete(id))
                return Ok("Customer deleted.");
            else
                return NoContent();
        }
    }
}
