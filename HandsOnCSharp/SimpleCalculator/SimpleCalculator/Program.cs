namespace SimpleCalculator;

class Program
{
    static void Main(string[] args)
    {


        try
        {
            InputConverter inputConverter = new();
            CalculatorEngine calculatorEngine = new();

            double firstNumber = inputConverter.ConvertInputToNumeric(Console.ReadLine());
            double secondNumber = inputConverter.ConvertInputToNumeric(Console.ReadLine());

            string operation = Console.ReadLine();

            double result = calculatorEngine.Calculate(operation, firstNumber, secondNumber);
            Console.WriteLine(result);
        }
        catch (Exception e)
        {
            // in real world we would want to log this message
            Console.WriteLine(e.Message);
        }
        














    }
}