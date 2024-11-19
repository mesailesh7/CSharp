namespace AbilityScore;

class Program
{
    static void Main(string[] args)
    {

        // static int ReadInt(int defaultValue, string prompt);
        // static double ReadDouble(double defaultValue, string prompt);

        static int ReadInt(int defaultValue, string prompt)
        {
            Console.Write(prompt + " [" + defaultValue + "] ");
            string? line = Console.ReadLine();

            if (int.TryParse(line, out int value))
            {
                Console.WriteLine("       using value   " + value);
                return value;
            }
            else
            {
                Console.WriteLine("      using default value  " + defaultValue);
                return defaultValue;
            }
        }



        static double ReadDouble(double defaultValue, string prompt)
        {
            Console.Write(prompt + " [" + defaultValue + "] ");
            string? line = Console.ReadLine();
            if (double.TryParse(line, out double value))
            {
                Console.WriteLine("       using value   " + value);
                return value;
            }
            else
            {
                Console.WriteLine("      using default value  " + defaultValue);
                return defaultValue;
            }
        }
        
        
        // char keyChar = Console.ReadKey();
        
        AbilityScoreCalculator calculator = new AbilityScoreCalculator();
        while (true)
        {
            calculator.RollResult = ReadInt(calculator.RollResult, "Starting 4d6 roll result");
            calculator.DivideBy = ReadDouble(calculator.DivideBy, "Divide by 1d");
            calculator.AddAmount = ReadInt(calculator.AddAmount, "Add amount");
            calculator.Minimum = ReadInt(calculator.Minimum, "Minimum");
            calculator.CalculateAbilityScore();
            Console.WriteLine("Calculated ability score: " + calculator.Score);
            Console.WriteLine("Press q to quit, any other key to continue...");
            char keyChar = Console.ReadKey(true).KeyChar;
            if((keyChar == 'q') || (keyChar == 'Q')) return;
        }
    }
}