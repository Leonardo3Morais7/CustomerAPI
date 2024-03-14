using CustomerAPI.Domain;

namespace CustomerAPI.Application;

public interface ICustomerService
{
    Task<IEnumerable<Customer>> GetAll();
    Task<Customer> Get(int id);
    Task<IEnumerable<Customer>> Add(List<Customer> customers);
    Task<bool> Update(Customer customer);
    Task<bool> Delete(int id);
}
