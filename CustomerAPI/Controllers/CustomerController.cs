using CustomerAPI.Application;
using CustomerAPI.Domain;
using CustomerAPI.Service;
using Microsoft.AspNetCore.Mvc;

namespace CustomerAPI.Controllers
{
    [Route("api/customer")]
    [ApiController]
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
        public void Post([FromBody] List<Customer> customers)
        {
            _customerService.Add(customers);
        }

        // PUT api/customer/{id}
        [HttpPut]
        public void Put([FromBody] Customer customer)
        {
            _customerService.Update(customer);
        }

        // DELETE api/customer/{id}
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _customerService.Delete(id);
        }
    }
}
