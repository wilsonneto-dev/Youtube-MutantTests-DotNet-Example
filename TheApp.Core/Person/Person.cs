namespace TheApp.Core.Person;

public class Person
{
    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public int Age { get; private set; }

    public Person(string name, int age)
    {
        Id = Guid.NewGuid();
        Name = name;
        Age = age;
        Validate();
    }

    private void Validate()
    {
        if(string.IsNullOrEmpty(Name) || Name.Split(' ').Length < 2)
            throw new Exception("Name should be composed by name and surname");
    }

    public bool IsOverMajorityAge() => Age >= 18;
}
