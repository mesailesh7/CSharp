// See https://aka.ms/new-console-template for more information

Console.WriteLine("Hello, World!");

Console.WriteLine("Hello, World!");

string firstFriend = "Maria";
string secondFriend = "Scott";

// $"" is called string interpolation
// is to concaniation the words
Console.WriteLine($"My friends are {firstFriend} {secondFriend}");

// c# compiling time red = errors and yellow for warning
Console.WriteLine("My friend is " + firstFriend + " and" + secondFriend);

// Its always best to trim the string so that you can remove the before and end 
string greeting = "         hello world         ";
Console.WriteLine(greeting.TrimStart());
Console.WriteLine(greeting.TrimEnd());
Console.WriteLine(greeting.Trim());


string friends = $"my friends are {firstFriend} {secondFriend}";
Console.WriteLine(friends);
Console.WriteLine(friends.Replace("Maria", "Hi"));
Console.WriteLine(friends);

//string in .net are immeutable it cannot be changed unless its explicit
friends = friends.Replace("Scott","Damian");
Console.WriteLine(friends);
Console.WriteLine(friends.Contains("Scott"));
Console.WriteLine(friends.ToUpper());

Console.WriteLine(friends.Length);
Console.WriteLine(friends.StartsWith("Sco"));
