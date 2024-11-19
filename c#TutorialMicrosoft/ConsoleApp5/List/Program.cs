// // See https://aka.ms/new-console-template for more information
//
// // Console.WriteLine("Hello, World!");
//
// // Arrays are fixed in length
// // list keeps on expanding with the length
//
// var names = new List<string>{"Sunny","Ana","Fred"};
// names.Add("David");
// names.Add("Julie");
// names.Remove("Sunny");
//
// foreach (var name in names)
// {
//     Console.WriteLine($"hello {name.ToUpper()}");
// }
//
// for (int i = 0; i < names.Count; i++)
// {
//     Console.WriteLine(names[i].ToUpper());
// }
//
// Console.WriteLine(names[0]);
// Console.WriteLine(names[2]);
//
// Console.WriteLine(names[names.Count-1]);
// Console.WriteLine(names[^1]);
//
// // lastNames.Add("Thapa"); arrays are fixed in length so cannot be expanded unless you create a new array
//
//
//
// var lastNames=new string[] {"David","Julie"};
// lastNames = [..lastNames, "Thapa"];
//
// foreach (var lastName in lastNames)
// {
//     Console.WriteLine("lastname is " + lastName);
// }
//
//


var names = new List<string>{"Scott", "Milk", "Tomato"};

names.Sort();

foreach (var name in names)
{
    Console.WriteLine(name);
}

var grades = new List<int> { 1, 2, 5, 7, 8, 12, 3, 4 };

grades.Sort();

foreach (var grade in grades)
{
    Console.WriteLine(grade);
}