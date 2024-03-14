using CustomerAPI.Application;
using CustomerAPI.Domain;
using Microsoft.Extensions.WebEncoders.Testing;

namespace CustomerAPI.Service;

public class CustomerService : ICustomerService
{
    private readonly ICustomerRepository _costumerRepository;

    public CustomerService(ICustomerRepository costumerRepository)
    {
        _costumerRepository = costumerRepository;
    }

    public void Add(List<Customer> values)
    {
        throw new NotImplementedException();
    }

    public void Delete(int id)
    {
        throw new NotImplementedException();
    }

    public Task<Customer> Get(int id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Customer>> GetAll()
    {
        throw new NotImplementedException();
    }

    public void Update(int id, Customer value)
    {
        throw new NotImplementedException();
    }
}
