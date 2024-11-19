using System.Security.Principal;

namespace TutorialProjectOOP;

public class Person
{
    //private fields
    private string _firstName = "";
    private string _lastName = "";
    private string _occupation = "";
    private int _age = 0;
    private int _count = 34;
    
    //public fields
    public string FirstName { get => _firstName; }

    public string LastName { get => _lastName; }

    public string Occupation { get => _occupation; }
    
    public int Age { get => _age;  }


    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="firstName">Person's first name</param>
    /// <param name="lastName">Person's last name</param>
    /// <param name="occupation">Person's occupation</param>
    /// <param name="age">Person's age</param>
    public Person(string firstName, string lastName, string occupation, int age)
    {
        _firstName = firstName;
        _lastName = lastName;
        _occupation = occupation;
        _age = age;
    }
    
    
}   