namespace Methods;
// using static System.Console;

class Program
{
    static void Main(string[] args)
    {
        // for (int i = 0; i < 10; i++)
        // {
        //     SampleMethods.SayHi();
        // }

        // string name = ConsoleMessages.GetUsersName();
        //
        // ConsoleMessages.SayHi(name);
        //
        // MathShortcuts.Add(5, 3);
        //
        // double[] vals = new double[5] { 2, 5, 6, 21, 52};
        // MathShortcuts.AddAll(vals);
        //
        // (string, string) fullName =  ConsoleMessages.GetFullName();
        // Console.WriteLine($"{fullName.Item1} {fullName.Item2}");

        string name = welcomeUser.WelcomeMessage();
        Console.WriteLine($"Hello {name}!");
        
    }
}