using System.Threading.Channels;

namespace BasicClass;

public class BaseClass
{
    public class Person
    {
        

        public Person(string name)
        {
            Name = name;
        }

        public string Name { get; private set; }

        public void PrintGreeting()
        {
            Console.WriteLine($"Hello, {Name}");
        }

        public string GetGreeting()
        {
            return $"Hello, {Name}";
        }

        public class Math
        {
            public int Sum(int a, int b)
            {
                return a + b;
            }

            public int Minus(int a, int b)
            {
                return a - b;
            }
            
        }
    }
    
}

public static class myMath
{
    public static int Minus(int a, int b)
    {
        return a - b;
    }
}