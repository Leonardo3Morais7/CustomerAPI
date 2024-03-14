using CustomerAPI.Domain;

namespace CustomerAPI.Application;

public interface ICustomerService
{
    Task<IEnumerable<Customer>> GetAll();
    Task<Customer> Get(int id);
    void Add(List<Customer> values);
    void Update(int id, Customer value);
    void Delete(int id);
}
