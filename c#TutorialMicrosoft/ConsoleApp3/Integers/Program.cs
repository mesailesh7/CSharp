// See https://aka.ms/new-console-template for more information

// int a = 18;
// int b = 6;
// int c = a + b;
// Console.WriteLine(c);

using System.Threading.Channels;

int a = 2100000000;
int b = 2100000000;
// long c = (long)a * (long)b; // Type casting where we are changing integer data type to long . its also like expliciting telling the ide whatever type it is change it to the casting type
// long d = checked(a * b); // this will make sure overflow never happens runtime exception if any kind of fail 
// Console.WriteLine(c);


//note: suffix goes at the end and prefix goes at the beginning
double d = 42.1; // natural type
float e = 38.2F;

double f = d + e;
Console.WriteLine(f);
Console.WriteLine($"the answer is {f}");




decimal g = 42.1m; //explicit type
decimal h = 38.2m;
decimal i = g + h;
Console.WriteLine(i);
