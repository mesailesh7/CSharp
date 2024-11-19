using System.Numerics;
using System.Security.Principal;
using System.Threading.Channels;

namespace ClassDemo;

public class Person
{
    //Access modifer
    private string _name = string.Empty;

    //Constructor
    public Person()
    {
        _name = "Claudio";
    }


    public string Name
    {
        get => _name;
        

    }
}





