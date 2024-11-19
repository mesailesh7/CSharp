namespace Methods;

public class MathShortcuts
{
    public static double Add(double x, double y)
    {
        // Console.WriteLine($"{x} + {y} = {x + y}");
        double output = x + y;
        return output;
    }

    public static void AddAll(double[] values)
    {
        double result = 0;
        foreach (double value in values)
        {
            result += value;
        }
        
        // or you can also do it using values.Sum();

        Console.WriteLine($"The total is {result}");
    }
}