namespace GuestBook;

public static class GuestList
{
    public static void WelcomeMessage()
    {
        //WelcomeMessage
        Console.WriteLine("Welcome to the guest Book application!");
        Console.WriteLine("****************************************");
        Console.WriteLine();
    }

    public static string GetPartyName()
    {
        //GetPartyName
        Console.WriteLine("What is your party/group name:");
        string output = Console.ReadLine() ?? "";
        return output;
    }

    public static int GetPartySize()
    {
        bool isValidNumber;
        int output;
        do
        {
            Console.WriteLine("How many people are in your party");
            string partySizeText = Console.ReadLine() ?? "";
            isValidNumber = int.TryParse(partySizeText, out output);
        } while (!isValidNumber);
        
        return output;
    }


    public static bool AskToContinue()
    {
        Console.Write("Are there more guest coming (yes/no)");
        string continueLooping = Console.ReadLine() ?? ""; 
        
        bool output = (continueLooping.ToLower() == "yes");
        return output;
    }
    
    public static (List<string> guests, int total) GetAllGuests()
    {
        int totalGuests = 0;
        
        List<string> guests = new List<string>();
        
        //Welcome Message
        
        do{
            guests.Add(GetPartyName()); 
                    
            //get party size
            totalGuests += GetPartySize();
            
            
            
        }
        while(AskToContinue());
        return (guests, totalGuests);
    }

    public static void DisplayGuest(List<string> guests)
    {
        foreach (string guest in guests)
        {
            Console.WriteLine(guest);
        }
    }


    public static void DisplayGuestCount(int totalGuest)
    {
        Console.WriteLine($"Thank you for everone who attended");
        Console.WriteLine($"The total guest count for this event was {totalGuest}");
 
    }
}