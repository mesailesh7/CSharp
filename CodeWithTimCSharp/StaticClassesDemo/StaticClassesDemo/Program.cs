namespace StaticClassesDemo;

class Program
{
    //basic of programming use only public or private
    static void Main(string[] args)
    {
        // Console.WriteLine("hello world");
        // SayHello();
        //



        string firstName = RequestData.GetAString("What is your name");
        UserMessages.ApplicationStartMessage()firstName;
        
        double x = RequestData.GetADouble("Please enter your first number");
        double y = RequestData.GetADouble("Please enter your second number");
        
        

    }

    private static void SayHello()
    {
        Console.WriteLine("Hello");
    }
}