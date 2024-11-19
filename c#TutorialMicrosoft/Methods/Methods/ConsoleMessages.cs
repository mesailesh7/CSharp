using System.Threading.Channels;

namespace Methods;

//make a call directly method

//dry
/// <summary>
/// DRY - Don't repeat yourself
/// </summary>
/// SOLID = SRP     SINGLE Responsibility Principle


public static class ConsoleMessages
{
    public static void SayHi(string firstName)
    {
        Console.WriteLine($"Hello, {firstName}!");
        Console.WriteLine("I hope you are having a good day");
    }

    public static string GetUsersName()
    {
        Console.WriteLine("what is your name");
        string name = Console.ReadLine() ?? "";
        return name;
    }

//Tuple allowos you to return 2 or more values
    public static (string, string) GetFullName()
    {
        Console.WriteLine("What is your first name");
        string firstName = Console.ReadLine();

        Console.WriteLine("What is your Last name");
        string lastName = Console.ReadLine();
        
        return (firstName, lastName);

    }
    
    public static void SayGoodBye()
    {
        Console.WriteLine("Boodbye, my lover");
        Console.WriteLine("Goodbye my friends");
    }
}

