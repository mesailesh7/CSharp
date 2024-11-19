// See https://aka.ms/new-console-template for more information
Random random = new Random();
bool playAgain = true;
String player;
string computer;


while (playAgain)
{
    player = "";
    computer = "";


    while (player != "ROCK" && player != "PAPER" && player != "SCISSORS")
    {
        Console.WriteLine("Welcome to Rock, Paper, Scissors!");
        Console.WriteLine("Please enter your name:");
        player = Console.ReadLine();
        player = player.ToUpper();
        Console.WriteLine("Hello " + player);
    }

    switch (random.Next(1, 4))
    {
        case 1:
            computer = "ROCK";
            break;
        case 2:
            computer = "PAPER";
            break;
        case 3:
            computer = "SCISSORS";
            break;
    }

    Console.WriteLine("You chose " + player);
    Console.WriteLine("Computer chose " + computer);

    switch (player)
    {
        case "ROCK":
            if (computer == "ROCK")
            {
                Console.WriteLine("It's a tie!");
            }
            else if (computer == "PAPER")
            {
                Console.WriteLine("You lose!");
            }
            else
            {
                Console.WriteLine("You win!");
            }
            break;
        case "PAPER":
            if (computer == "ROCK")
            {
                Console.WriteLine("You win!");
            }
            else if (computer == "PAPER")
            {
                Console.WriteLine("It's a tie!");
            }
            else
            {
                System.Console.WriteLine("You lose!");
            }
        case "SCISSORS":
        
    }

}
