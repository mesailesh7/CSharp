using PokemonRPG.Models;
using PokemonRPG.Models.Players;

namespace PokemonRPG.Console;

public class Program
{
    static void Main(string[] args)
    {
        var battleManager = new BattleSystem.BattleManager();

        var player1 = new COMPlayer("AI Player 1");
        var player2 = new COMPlayer("AI Player 2");

        player1.Party = new List<BaseMonster>
        {

        };
        
        System.Console.WriteLine("Hello, World!");
    }
}