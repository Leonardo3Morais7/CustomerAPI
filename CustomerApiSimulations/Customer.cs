namespace CustomerAPI.Domain;

public class Customer
{
    private List<string> _firstNames = new List<string>() 
    {
        "Leia","Sadie","Jose","Sara","Frank","Dewey","Tomas","Joel","Lukas","Carlos"
    };
    private List<string> _secondNames = new List<string>() 
    {
        "Liberty","Ray","Harrison","Ronan","Drew","Powell","Larsen","Chan","Anderson","Lane"
    };

    public int Id { get; set; }
    public int Age { get; set; }
    public string FirstName { get; set; }
    public string SecondName { get; set; }

    public Customer(int id)
    {
        var rnd = new Random();

        Id = id;
        Age = rnd.Next(10,90);
        FirstName = _firstNames[rnd.Next(0, _firstNames.Count)];
        SecondName = _secondNames[rnd.Next(0, _secondNames.Count)];
    }

    public override string ToString()
    {
        return $"Id: {Id}, Age: {Age}, FirstName: {FirstName}, SecondName: {SecondName}";
    }
}
