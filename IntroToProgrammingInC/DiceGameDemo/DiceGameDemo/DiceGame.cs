using Microsoft.VisualBasic;
using static System.Console;

namespace DiceGameDemo;


public class DiceGame
{
    private string GameName;
    private Random RandomGenerator;
    private int Score;

    public DiceGame()
    {
        //Initiliaze anything that we need to:
        Score = 0;
        GameName = "Roll R Us";
        RandomGenerator = new Random();
        
        
    }


    public void Start()
    {
        //Method that start the game running.
        Title = GameName;
        WriteLine($"==={GameName}===");
        Title = GameName;
        WriteLine($"=== {GameName} ===");
        WriteLine("InLet's play a game of chance with dice.");
        WriteLine("|nInstructions:");
        WriteLine("\t› I will roll a die each round.");
        WriteLine("It› You will guess if it is high or low.");
        WriteLine("\t› If you get it right, I'll give you a point.");
        WriteLine("InReady to play? (yes/no) ");

        
        string playResponse = ReadLine();
        if (playResponse == "yes")
        {
            WriteLine("Dang okay lets play");
            PlayRound();
        }
        else
        {
            WriteLine("May be next time MF");
        }
        
        
        
        
        WriteLine("Press any key to exit");
    }

    private void PlayRound()
    {
        //method that runs one round of rolling and guessing
        Clear();
        WriteLine("I am about to roll ");
        WriteLine("Is it going to be low ( 1,2,3) or high (4,5,6)");
        
        string response = ReadLine().Trim().ToLower();
        WriteLine($"You guessed {response}");
        
        int roll = RandomGenerator.Next(1, 7);
        WriteLine($"The die was {roll}.");


        if (response == "high")
        {
            WriteLine($"You guessed high");
            if (roll <= 3)
            {
                WriteLine("You lose");
            }
            else
            {
                WriteLine("You win");
            }
        } else if (response == "low")
        {
            WriteLine($"You guessed low");
            if (roll <= 3)
            {
                WriteLine("You win");
            }
            else
            {
                WriteLine("You lose");
            }
        }
        else
        {
            WriteLine($"You guessed {response}. That's not a valid. Try again with 'high' or 'low'");
        }
        
        WriteLine("Press any key to continue");
        ReadKey();
        PlayRound();

    }

    private void Win()
    {
        
    }

    private void Lose()
    {
        //method that lets the player know that they lost
    }

    private void AskToPlayAgain()
    {
        //method to asks the player if they want to play again
    }
    
    

    
}