using CustomerAPI.Application;
using CustomerAPI.Domain;
using System.Text.Json;

namespace CustomerAPI.Repository;

public class CustomerRepository : ICustomerRepository
{
    private List<Customer> _customerList;

    public CustomerRepository()
    {
        _customerList= new List<Customer>();
    }

    public void Add(Customer entity)
    {
        throw new NotImplementedException();
    }

    public void Delete(Customer entity)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Customer> GetAll()
    {
        throw new NotImplementedException();
    }

    public Customer GetById(int id)
    {
        throw new NotImplementedException();
    }

    public void Update(Customer entity)
    {
        throw new NotImplementedException();
    }
}
