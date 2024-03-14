using CustomerAPI.Application;
using CustomerAPI.Domain;
using System.Text.Json;

namespace CustomerAPI.Repository;

public class CustomerRepository : ICustomerRepository
{
    private List<Customer> _customerList;

    public CustomerRepository()
    {
        var options = new JsonSerializerOptions()
        {
            PropertyNameCaseInsensitive = true,
        };

        var data = JsonSerializer.Deserialize<List<Customer>>
            (
                File.ReadAllText("CustomerData.json"),
                options
            );

        _customerList = data.ToList();
    }

    public void UpdateDataFile() 
    {
        File.WriteAllText("CustomerData.json", JsonSerializer.Serialize(_customerList));
    }

    public void Add(Customer customer)
    {
        for (int i = 0; i <= _customerList.Count; i++)
        {
            if (i == _customerList.Count) 
            {
                _customerList.Add(customer);
                break;
            }

            var secondNameOrder = OrderedNames(customer.SecondName, _customerList[i].SecondName);
            if (secondNameOrder == 1) 
            {
                _customerList.Insert(i, customer);
                break;
            }
            else if (secondNameOrder == 0)
            {
                var firstNameORder = OrderedNames(customer.FirstName, _customerList[i].FirstName);
                if (firstNameORder == 1 || firstNameORder == 0) 
                {
                    _customerList.Insert(i, customer);
                    break;
                }
            }
        }

        UpdateDataFile();
    }

    public void Delete(int id)
    {
        //_customerList.Remove(GetById(id));
        for (int i = 0; i < _customerList.Count; i++)
        {
            if (_customerList[i].Id == id)
            { 
                _customerList.RemoveAt(i);
                break;
            }
        }
        UpdateDataFile();
    }

    public IEnumerable<Customer> GetAll()
    {
        return _customerList;
    }

    public Customer GetById(int id)
    {
        //return _customerList.Where(i => i.Id == id).First();

        foreach (var customer in _customerList)
        {
            if(customer.Id == id)
                return customer;
        }
        return null;
    }

    public void Update(Customer customer)
    {
        //var current = _customerList.Where(i => i.Id == customer.Id).First();
        //current = customer;

        for(int i = 0; i < _customerList.Count; i++) 
        {
            if (_customerList[i].Id == customer.Id) 
            {
                _customerList[i].Age = customer.Age;
                _customerList[i].FirstName = customer.FirstName;
                _customerList[i].SecondName = customer.SecondName;
            }
        }
        UpdateDataFile();
    }

    public int OrderedNames(string firstName, string secondName)
    {
        if(firstName == secondName)
            return 0;

        firstName= firstName.ToLower();
        secondName= secondName.ToLower();
        var minStringLength = Math.Min(firstName.Length, secondName.Length);


        for (int i = 0; i < minStringLength; i++) 
        {
            if (Convert.ToInt16(firstName[i]) > Convert.ToInt16(secondName[i]))
            {
                return -1;
            }
            else if (Convert.ToInt16(firstName[i]) < Convert.ToInt16(secondName[i])) 
            {
                return 1;
            }
        }

        if (firstName.Length > secondName.Length)
            return -1;
        else
            return 1;
    }
}
