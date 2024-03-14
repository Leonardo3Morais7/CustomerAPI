using CustomerAPI.Domain;

namespace CustomerAPI.Application;

public interface ICustomerService
{
    Task<IEnumerable<Customer>> GetAll();
    Task<Customer> Get(int id);
    void Add(List<Customer> customers);
    void Update(Customer customer);
    void Delete(int id);
}
