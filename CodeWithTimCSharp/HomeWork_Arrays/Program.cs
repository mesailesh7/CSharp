// See https://aka.ms/new-console-template for more information

Console.WriteLine("Hello, World!");

/*
HOMEWORK
    Create an array of 3 names. Ask the user which
number to select. When the user gives you a
    number, return that name. Make sure to check
for invalid numbers.

*/

/*
Console.WriteLine("Please enter the number between 1 to 3 to get a number");

string[] names = new string[3] {"Ram","Hari","Sita"};

int SelectedNumber = int.Parse(Console.ReadLine() ?? "");

if (SelectedNumber <= 3)
{
    Console.WriteLine(names[SelectedNumber]);
}
else
{
    Console.WriteLine("Please enter the number between 1 to 3 please");
}
*/

//
// HOMEWORK
//     Add students to a class roster List until there are
// no more students. Then print out the count of
//     the students to the Console.

/*
 * make a empty list
 * then take the input
 * loop the input until they say done
 *  once done output in the console
 */

// List<string> students = new List<string>();
//
// Console.WriteLine("Please enter the students and enter Done once finished ");
// string studentName = (Console.ReadLine() ?? "").ToUpper();
//
// while (studentName != "Done")
// {
//     students.Add(studentName);
// }
//
// Console.WriteLine("Thank you");
// Console.WriteLine($"You have added {students.Count} names in the database");

List<string> names = new List<string>();
string input = "";

while (input.ToUpper() != "DONE")
{
    Console.Write("Enter name: ");
    input = Console.ReadLine();

    if (input.ToUpper() != "DONE")
    {
        names.Add(input);
    }
}

Console.WriteLine("Names entered: " + string.Join(", ", names));