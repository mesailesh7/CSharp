using Microsoft.VisualBasic;
using static System.Console;

namespace ExplorableWorld;
public class Game
{
    private World MyWorld;
    private Player CurrentPlayer;
    
    public void Start()
    {
        Title = "Welcome to the maze";
        CursorVisible = false;
        WriteLine("Game is starting...");
        
        
        // SetCursorPosition(4, 2);
        // Write("X");

        // string[,] grid =
        // {
        //     {"1","2","3" },
        //     {"4","5","6" },
        //     {"7","8","9" },
        // };
    
        WriteLine();

        string[,] grid =
        {
            { "=", "=", "=", "=", "=", "=", "=" },
            { "=", " ", "=", " ", " ", " ", "X" },
            { " ", " ", "=", " ", "=", " ", "=" },
            { "=", " ", "=", " ", "=", " ", "=" },
            { "=", " ", " ", " ", "=", " ", "=" },
            { "=", "=", "=", "=", "=", "=", "=" }
        };
        
        // int row = grid.GetLength(0);
        // int cols = grid.GetLength(1);
        //
        // // y = row and x = columns
        // for (int y = 0; y < row; y++)
        // {
        //     for (int x = 0; x < cols; x++)
        //     {
        //     string element = grid[y, x];
        //     SetCursorPosition(x,y);
        //     Write(element);
        //     }
        //     
        // }
        
        MyWorld = new World(grid);    
        // WriteLine(myWorld.IsPositionWalkable(0,0));//False
        // WriteLine(myWorld.IsPositionWalkable(1,1));//True
        // WriteLine(myWorld.IsPositionWalkable(6,1));//True

        CurrentPlayer = new Player(0, 2);
        
        RunGameLoop();
        
        

        // WriteLine("\n\n press any key to exit...");
        ReadKey();
    }

    private void DisplayIntro()
    {
        WriteLine ("Welcome to the maze!");
        WriteLine("\ninstructions");
        WriteLine("› Use the arrow keys to move");
        Write("› Try to reach the goal, which looks like this: ");
        ForegroundColor = ConsoleColor. Green;
        WriteLine ("X");
        ResetColor();
        WriteLine("› Press any key to start");
        ReadKey (true);
    }

    private void DisplayOutro()
    {
        Clear();
        WriteLine ("You escaped!");
        WriteLine("Thanks for playing.");
        WriteLine("Press any enter to exit...");
        ReadKey (true);
    }
    
    
    private void DrawFrame()
    {
        Clear();
        MyWorld.Draw();
        CurrentPlayer.Draw();
    }

    private void HandlePlayerInput()
    {
        ConsoleKeyInfo keyInfo = ReadKey(true);
        ConsoleKey key = keyInfo.Key;
        switch (key)
        {
            case ConsoleKey.UpArrow:
                if (MyWorld.IsPositionWalkable(CurrentPlayer.X, CurrentPlayer.Y - 1))
                {
                CurrentPlayer.Y -= 1;
                }
                break;
            case ConsoleKey.DownArrow:
                if (MyWorld.IsPositionWalkable(CurrentPlayer.X, CurrentPlayer.Y + 1))
                {
                    
                CurrentPlayer.Y += 1;
                }
                break;
            case ConsoleKey.LeftArrow:
                if (MyWorld.IsPositionWalkable(CurrentPlayer.X - 1, CurrentPlayer.Y))
                {
                CurrentPlayer.X -= 1;
                }
                break;
            case ConsoleKey.RightArrow:
                if (MyWorld.IsPositionWalkable(CurrentPlayer.X + 1, CurrentPlayer.Y))
                {
                CurrentPlayer.X += 1;
                }
                break;
            default:
                break;
                
        }
    }

    private void RunGameLoop()
    {
        DisplayIntro();
        while (true)
        {
        //Draw everything
        DrawFrame();
        //Check for player input from the keyboard and move the player
        HandlePlayerInput();
        //Check if the player ha sreached the exit and end the game if so
        //Todo
        string elementAtPlayerPos = MyWorld.GetElements(CurrentPlayer.X, CurrentPlayer.Y);
        if (elementAtPlayerPos == "X")
        {
            break;
        }
        
        //Give the console a chance to render.
        Thread.Sleep(20);
            // break;
        }
        DisplayOutro();
    }
}