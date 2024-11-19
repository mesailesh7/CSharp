// See https://aka.ms/new-console-template for more information

using System.Runtime.Intrinsics.Arm;

int num1;
int num2;
string answer;
int result = 0;


Console.WriteLine("Hello welcome to the calculator program");
Console.WriteLine("Please enter your first number");

num1 = int.Parse(Console.ReadLine() ?? "");

Console.WriteLine("Please enter your second number");

num2 = int.Parse(Console.ReadLine() ?? "");

Console.WriteLine("What type of operation would you like to do!");
Console.WriteLine("Please enter a for addition, s for substraction, m for multiplication, d for division");

answer = Console.ReadLine() ?? "";


if (answer == "a")
{
    result = num1 + num2;
}
else if(answer == "s")
{
    result = num1 - num2;
}
else if(answer == "m")
{
    result = num1 * num2;
} else if (answer == "d")
{
    result = num1 / num2;
}
else
{
    Console.WriteLine("Please enter a for addition, s for substraction, m for multiplication , d for division");
}


Console.WriteLine($"You answer for {num1} {answer} {num2} is {result}");