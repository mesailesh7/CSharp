using System.Drawing;
using static System.Console;
using System.Threading.Tasks;
using System.Text;
using System.Collections.Generic;


namespace InheritanceGameDemo;


public class Game
{

    
    // private Anaconda Seshnaag;
    private Player CurrentPlayer;
    
    
    private List<Character> Enemies;
    
    
    public Game()
    {
        Ant FireAuntie = new("Fire Auntie",100,ConsoleColor.Red,3);
        
        Ant Hades = new("Hades",200,ConsoleColor.Magenta,6);
        Item LeafNinjaStar = new Item("Leaf Ninja Star",10);
        Hades.PickUpItem(LeafNinjaStar);
        
        Bee buzzBee = new("BuzzBee", 75, ConsoleColor.DarkYellow, true);
        Anaconda Seshnaag = new Anaconda("Seshnaag", 100, ConsoleColor.DarkRed, 8);

        //Polymorphisam in action!
        Enemies = new List<Character>(){FireAuntie,Hades,buzzBee,Seshnaag};
        // or
        // Enemies.Add(FireAuntie);
    }

    public void Run()
    {
        WriteLine("##### Micro RPG ##### \n");
        
        CurrentPlayer = new Player("Sunny",50,ConsoleColor.Green);
        CurrentPlayer.DisplayInfo();
        
        

        

        foreach (var enemy in Enemies)
        {
            enemy.DisplayInfo();
            enemy.Fight();
            WriteLine();
            
            
            
            // WriteLine("Instance info");
            // WriteLine($"What is this instance? {enemy.GetType()}");
            // WriteLine($"Is this object? {enemy is object}");
            // WriteLine($"Is this object? {enemy is Character}");
            // WriteLine($"Is this object? {enemy is Bee}");
            // WriteLine($"Is this object? {enemy is Ant}");
            // WriteLine($"Is this object? {enemy is Anaconda}");
            //
            //
            // if (enemy is Ant)
            // {
            //     Ant ant = enemy as Ant;
            //     ant.Bite();
            //     ant.Charge();
            // }
            // else if (enemy is Bee)
            // {
            //     Bee bee = enemy as Bee;
            //     bee.FLy();
            //     bee.Sting();
            // }
            
            
        }
        
        // FireAuntie.DisplayInfo();
        // WriteLine();
        // FireAuntie.Charge();
        // FireAuntie.Bite();
        // WriteLine();
        //
        // Hades.DisplayInfo();
        // WriteLine();
        // Hades.Charge();
        // Hades.Bite();
        // WriteLine();
        //
        //
        // BuzzBee.DisplayInfo();  
        // WriteLine();
        // BuzzBee.FLy();
        // BuzzBee.Sting();
        // WriteLine();
        //
        //
        // Seshnaag.DisplayInfo();
        // WriteLine();
        // Seshnaag.Charge();
        // Seshnaag.Bite();
        // WriteLine();
        
        
        WaitForKey();
    }

    public void WaitForKey()
    {
        WriteLine("Press any key to continue .... \n");
        ReadKey(true);
    }
}