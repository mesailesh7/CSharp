namespace DiceGameDemo;
using static Console;


class Program
{
    static void Main(string[] args)
    {
        
        
        
        //Demos to do
        //random
        //if statements
        //switch statements
        // Random  myRandGenerator = new Random();
        // int randNumebr = myRandGenerator.Next(1, 7);
        // WriteLine($"A random number is {randNumebr}");
        //
        //
        // if (randNumebr == 1)
        // {
        //     WriteLine("You got a one");
        // }
        // else
        // {
        //     WriteLine("You didn't not get a one");
        //     WriteLine("You are a loser");
        // }
        DiceGame myGame = new DiceGame();
        myGame.Start();
        
        
    }
}