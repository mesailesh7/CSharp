using ATMApp.UI;

namespace ATMApp;

class ATMApp
{
    static void Main(string[] args)
    {
        AppScreen.Welcome();
        var cardNumber = Utility.GetUserInput("Your card number");
        Console.WriteLine($"Your name is {cardNumber}");
        
        Utility.PressEnterToContinue();


    }
}