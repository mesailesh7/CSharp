namespace BasicClass;

class Program
{
    static void Main(string[] args)
    {
        BaseClass.Person person1 = new BaseClass.Person("Sunny");
        
        Console.WriteLine(person1.Name);

        string greeting = person1.GetGreeting();

        BaseClass.Person.Math math = new BaseClass.Person.Math();
        int result = math.Sum(14, 16);
        int result2 = myMath.Minus(15, 16);
        Console.WriteLine($"Minus result it {result2}");
        Console.WriteLine(result);
        Console.WriteLine(greeting);
    }
}