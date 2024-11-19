namespace StaticClassesDemo;

public class UserMessages
{
    public static void ApplicationStartMessage()
    {
        Console.WriteLine("Welcome to the static Class Demo App");

        int hourOfDay = DateTime.Now.Hour;
        
        if(hourOfDay < 12)
            Console.WriteLine("Good Morninng");
        else if(hourOfDay < 19)
            Console.WriteLine("Good Afternoon");
        else
            Console.WriteLine("Good Evening");
    }

    
}