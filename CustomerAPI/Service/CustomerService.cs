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

    public async Task<IEnumerable<Customer>> Add(List<Customer> customers)
    {
        var addedCostumers = new List<Customer>();

        foreach (var customer in customers) 
        {
            if (customer.Id <= 0 || _customerRepository.GetById(customer.Id) != null)
                continue;
            if (string.IsNullOrEmpty(customer.FirstName) || string.IsNullOrEmpty(customer.SecondName))
                continue;
            if (customer.Age <= 18)
                continue;

            _customerRepository.Add(customer);
            addedCostumers.Add(customer);
        }

        return addedCostumers;
    }

    public async Task<bool> Delete(int id)
    {
        if (_customerRepository.GetById(id) != null)
        {
            _customerRepository.Delete(id);
            return true;
        }
        return false;
    }

    public async Task<Customer> Get(int id)
    {
        return _customerRepository.GetById(id);
    }

    public async Task<IEnumerable<Customer>> GetAll()
    {
        return _customerRepository.GetAll();
    }

    public async Task<bool> Update(Customer customer)
    {
        if (customer.Id > 0 && _customerRepository.GetById(customer.Id) != null) 
        {
            if (!string.IsNullOrEmpty(customer.FirstName) || !string.IsNullOrEmpty(customer.SecondName) || customer.Age > 18)
            { 
                _customerRepository.Update(customer);
                return true;
            }
        }
        return false;
    }
}
