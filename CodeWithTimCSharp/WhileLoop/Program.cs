// See https://aka.ms/new-console-template for more information

// Console.Write("what is your age:");
// string AgeText = Console.ReadLine();
//
// bool IsValidAge = int.TryParse(AgeText,out int age);
//
// if (IsValidAge == false)
// {
//     Console.WriteLine("that was an invalid age.");
//     return;
// }

//
// string data = "Ram,Sam,Mina,Tina,Hari,GOri";
// string[] names = data.Split(',');
//
// Console.Write(names[0]);

bool isValidAge;
int age;

do
{
    Console.Write("What is your age: ");
    string ageText = Console.ReadLine();
    isValidAge = int.TryParse(ageText, out  age);
    if (isValidAge == false)
    {
        Console.WriteLine("This was an invalid age.");
        
    }

} while(isValidAge == false);
Console.WriteLine($"Your age is {age}");