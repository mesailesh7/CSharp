namespace Methods;

public class welcomeUser
{
    public static string WelcomeMessage()
    {
        Console.WriteLine("Please enter your username");
        string userName = Console.ReadLine();
        return userName;
    }
}