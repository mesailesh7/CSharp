namespace TriviaGame;
using static Console;

public class Game
{
    private string GameTitleArt = @"

___________      .__      .__         ________                          __   
\__    ___/______|__|__  _|__|____    \_____  \  __ __   ____   _______/  |_ 
  |    |  \_  __ \  \  \/ /  \__  \    /  / \  \|  |  \_/ __ \ /  ___/\   __\
  |    |   |  | \/  |\   /|  |/ __ \_ /   \_/.  \  |  /\  ___/ \___ \  |  |  
  |____|   |__|  |__| \_/ |__(____  / \_____\ \_/____/  \___  >____  > |__|  
                                  \/         \__>           \/     \/       
";
    private string GameTitle = "Trivia Game";
    private string Description = "Battle your friends for the top score in silly Trivia Game";
    private Player currentPlayer;

    private TriviaItem UnicornTrivia;
    private TriviaItem OctoTrivia;
    private TriviaItem BleachTrivia;
    
    public Game()
    {
        string unicornQuestion = "The National Animal of Scotland is the Unicorn - true or false?";
        UnicornTrivia = new TriviaItem(unicornQuestion, "true");
                    
        string octoQuestion = "An octopus can fit through any hole larger than its beak - true or false?";
        OctoTrivia = new TriviaItem(octoQuestion, "true");
        
        string bleachQuestion = "Bleach never expires - true or false?";
        BleachTrivia = new TriviaItem(bleachQuestion, "false"); 

    }

    public void Play()  
    {
        Title = GameTitle;
        WriteLine(GameTitle);
        WriteLine($"Welcome to {GameTitle}!");
        WriteLine(Description);
        
        
        Write("What is your name?");
        string playerName = ReadLine();
        currentPlayer = new Player(playerName);
        WriteLine($"Welcome to {GameTitle}, {currentPlayer.Name}!");
        WriteLine($"Your current score is {currentPlayer.Score}");
        
        WriteLine("\n ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
        UnicornTrivia.AskQuestion();
        WriteLine(" ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
        
        
        WriteLine("\n ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
        OctoTrivia.AskQuestion();
        WriteLine(" ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
        
        
        WriteLine("\n ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
        BleachTrivia.AskQuestion();
        WriteLine(" ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");



    }
}