using CustomerAPI.Application;
using CustomerAPI.Domain;
using Microsoft.Extensions.WebEncoders.Testing;

namespace CustomerAPI.Service;

public class CustomerService : ICustomerService
{
    private readonly ICustomerRepository _customerRepository;

    public CustomerService(ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }

    public void Add(List<Customer> customers)
    {
        foreach (var customer in customers) 
        {
            if (customer.Id <= 0 || _customerRepository.GetById(customer.Id) != null)
                continue;
            if (string.IsNullOrEmpty(customer.FirstName) || string.IsNullOrEmpty(customer.SecondName))
                continue;
            if (customer.Age <= 18)
                continue;

            _customerRepository.Add(customer);
        }
    }

    public void Delete(int id)
    {
        if(_customerRepository.GetById(id) != null)
            _customerRepository.Delete(id);
    }

    public async Task<Customer> Get(int id)
    {
        return _customerRepository.GetById(id);
    }

    public async Task<IEnumerable<Customer>> GetAll()
    {
        return _customerRepository.GetAll();
    }

    public void Update(Customer customer)
    {
        if (customer.Id <= 0 || _customerRepository.GetById(customer.Id) != null) 
        {
            if (!string.IsNullOrEmpty(customer.FirstName) || !string.IsNullOrEmpty(customer.SecondName) || customer.Age > 18)
                _customerRepository.Update(customer);
        }
    }
}
