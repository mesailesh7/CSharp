namespace ATMApp.UI;

public static class AppScreen
{
    internal static void Welcome()
    {
        Console.Clear();
        Console.Title = "ATM App";
        Console.ForegroundColor = ConsoleColor.White;
        
        
        
        //set the welcome page
        Console.WriteLine("\n\nW--------------------elcome to my ATM Appn--------------\n\n");
        Console.WriteLine("Please insert your ATM card ");
        Console.WriteLine("Note: Actual atm machine will accept and validate a physical atm card, read the card number and validate");
        
        
        Utility.PressEnterToContinue();
    }

    
}