namespace CustomerAPI.Domain;

public class Customer
{
    public int Id { get; set; }
    public int Age { get; set; }
    public string FirstName { get; set; }
    public string SecondName { get; set; }

    public Customer(int id, int age, string firstName, string secondName)
    {
        Id = id;
        Age = age;
        FirstName = firstName;
        SecondName = secondName;
    }
}
