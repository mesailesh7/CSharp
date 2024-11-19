namespace StaticClassesDemo;

public class RequestData
{


    public static string GetAString(string message)
    {
        Console.WriteLine(message);
        string output = Console.ReadLine();
        return output;
    }
    
    
    
    
    
    
    
    public static double GetADouble(string message)
    {
        Console.WriteLine(message);
        string numberText = Console.ReadLine();
        double output;
        
        bool isDouble = double.TryParse(numberText, out output);

        while (isDouble == false)
        {
            Console.WriteLine("That was not a valid number. Please try again");
            Console.WriteLine(message);
            numberText = Console.ReadLine();
            
            isDouble = double.TryParse(numberText, out output);
        }
        return output;
    }
}