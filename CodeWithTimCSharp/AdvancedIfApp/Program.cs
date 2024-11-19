// See https://aka.ms/new-console-template for more information

// Console.Write("What is your first name: ");
// string firstName = Console.ReadLine() ?? "";
//
//
// Console.Write("What is your last name ");
// string lastName = Console.ReadLine() ?? "";

// if (firstName.ToLower() == "tim" && lastName.ToLower() == "corey")
// {
//     Console.WriteLine("Hello Mr.Corey");
// }
// else
// {
//     Console.WriteLine("Invalid user");
// }

//
// string firstName = "Tim";
// int age = 43;
//
// switch (firstName.ToLower())
// {
//     case "sue":
//         Console.WriteLine("hello professor");
//         break;
//     case "tom":
//         Console.WriteLine("Hello no body");
//         break;
//     
// }   

using System.Diagnostics;

int age = 0;

/*
switch (age)
{
    case 0:
        Console.WriteLine(("Hello world"));
        break;
    default:
        Console.WriteLine("Age doesn't match any case");
        break;  
}
*/

switch (age)
{
    case >=0 and < 18:
        Console.WriteLine("You are a child");
        break;
    case >=18 and <66:
        Console.WriteLine("You should have a job");
        break;
    case >= 66:
        Console.WriteLine("Hopefully you are retired or retiring soon");
        break;
    default:
        Console.WriteLine("Age was not in an expected range.");
        break;
}
