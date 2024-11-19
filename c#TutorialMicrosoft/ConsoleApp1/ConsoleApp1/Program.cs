// // See https://aka.ms/new-console-template for more information
//
// // WorkWithIntegeres();
// // OrderPrecedence();
// //TestLimits()
//
// //void seperate methods
// void TestLimits()
// {
//     
//     int a = 7;
//     int b = 4;
//     int c = 3;
//     int d = (a + b) / c;
//     int e = (a + d) % c;
//     Console.WriteLine($"quotient: {d}");
//     Console.WriteLine($"remainder: {e}");
//
//
//
//     int max = int.MaxValue;
//     int min = int.MinValue;
//     Console.WriteLine($"The range of integers is {min} to {max}");
//
//
//     int what = max + 3;
//     Console.WriteLine($"The numbers are {what}");
//
// }
//
// void WorkWithIntegeres()
// {
//     int a = 18;
//     int b = 6;
//     int c = a + b;
//     Console.WriteLine(c);
//     
//     //substraction
//     c = a - b;
//     Console.WriteLine(c);
//     
//     //multiplication
//     c = a * b;
//     Console.WriteLine(c);
//     
//     //division
//     c = a / b;
//     Console.WriteLine(c);
// }
//
// // int a = 5;
// // int b = 6;
// // int c = 2;
// // // int d = (a + b) * c;
// // int d = (a + b) - 6 * c + (12 * 4) / 3 + 12;
// // Console.WriteLine(d);
//
//
// //
// // int e = 7;
// // int f = 4;
// // int g = 3;
// // int h = (e + f) / g;
// // Console.WriteLine(h);
//
// void OrderPrecedence()
// {
//     int a = 5;
//     int b = 4;
//     int c = 2;
//     int d = a + b * c;
//     Console.WriteLine(d);
//     
//     d = (a + b) * c;
//     Console.WriteLine(d);
//     
//     d = (a + b) - 6 * c + (12 * 4) / 3 + 12;
//     Console.WriteLine(d);
//
//     int e = 7;
//     int f = 4;
//     int g = 3;
//     int h = (e + f) / g;
//     Console.WriteLine(h);
// }
//
//
// // int max = int.MaxValue;
// // int min = int.MinValue;
//
// // Console.WriteLine($"The numbers are {max} to {min}");
//
// // int what = max + 3;
// // Console.WriteLine($"The numbers are {what}");
//
//
// double a = 5;
// double b = 4;
// double c = 3;
// double d = (a+b) / c;
// // Console.WriteLine($"quotient: {d}");
//
//
// double e = 19;
// double f = 23;
// double g = 8;
// double h = (e + f) / g;
// // Console.WriteLine(h);
//
//
// double max = double.MaxValue;
// double min = double.MinValue;
// // Console.WriteLine($"The range of double is {min} to {max}");
//
// double third = 1.0/3.0;
// // Console.WriteLine(third);
//
//
//
// for (int row = 1; row < 11; row++)
// {
//     for (char column = 'a'; column < 'k'; column++)
//     {
//         Console.WriteLine($"{row}, {column}");
//     }
// }

List<string> names = ["Sunny","Ana","Felipe"];
foreach (var name in names)
{
    // Console.WriteLine(name);
}


Console.WriteLine();
names.Add("Maria");
names.Add("Bill");
names.Remove("Maria");
// foreach (var name in names)
// {
//     Console.WriteLine(name);
// }

// Console.WriteLine(names[0]);
// Console.WriteLine(names.Count);
//
// names.Sort();
// foreach (var name in names)
// {
//     Console.WriteLine();
// }
//

//WorkWithStrings();

void WorkWithStrings()
{
    List<string> names = ["Sunny","Ana","Felipe"];
    foreach (var name in names)
    {
        Console.WriteLine(name.ToUpper());
    }
    Console.WriteLine();
    names.Add("Maria");
    names.Add("Bill");
    names.Remove("Ana");
    foreach (var name in names)
    {
        Console.WriteLine(name.ToUpper());
    }

    Console.WriteLine(names[0]);

    Console.WriteLine(names.Count);
    
    var index = names.IndexOf("Maria");
    if (index == -1)
    {
        Console.WriteLine(index);
    }
    else
    {
        Console.WriteLine(names[index]);
    }
    
    index = names.IndexOf("Not Found");
    if (index == -1)
    {
        Console.WriteLine($"When an item is not found, IndexOf returns {index}");
    }
    else
    {
        Console.WriteLine($"The name {names[index]} is at index {index}");
    }
    names.Sort();
    foreach (var name in names)
    {
        Console.WriteLine($"Hello {name.ToUpper()}!");
    }
}

List<int> fibonnacciNumbers = [1,1];

// var previous = fibonnacciNumbers[fibonnacciNumbers.Count - 1];
// var previous2 = fibonnacciNumbers[fibonnacciNumbers.Count - 2];
//
// fibonnacciNumbers.Add(previous + previous2);


// See if you can put together some of the concepts from this and earlier lessons. Expand
//     on what you've built so far with Fibonacci Numbers. Try to write the code to generate
//     the first 20 numbers in the sequence. (As a hint, the 20th Fibonacci number is 6765.)
while (fibonnacciNumbers.Count < 20)
{
    var previous = fibonnacciNumbers[fibonnacciNumbers.Count - 1];
    var previous2 = fibonnacciNumbers[fibonnacciNumbers.Count - 2];

    fibonnacciNumbers.Add(previous + previous2);
}
foreach (var item in fibonnacciNumbers)
{
    Console.WriteLine(item);
};
