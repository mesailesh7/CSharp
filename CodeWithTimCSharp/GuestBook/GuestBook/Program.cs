namespace GuestBook;

class Program
{
    static void Main(string[] args)
    {



        
       //Welcome Message
        GuestList.WelcomeMessage();
        // (List<string> guests, int totalGuests) = GuestList.GetAllGuests();

        var (guests, totalGuest) = GuestList.GetAllGuests();
        
        GuestList.DisplayGuest(guests);

        GuestList.DisplayGuestCount(totalGuest);
        
        




    }
}