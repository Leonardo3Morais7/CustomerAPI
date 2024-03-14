using CustomerAPI.Domain;

namespace CustomerAPI.Application;

public interface ICustomerRepository
{
    Customer GetById(int id);
    IEnumerable<Customer> GetAll();
    void Add(Customer entity);
    void Update(Customer entity);
    void Delete(Customer entity);
}
