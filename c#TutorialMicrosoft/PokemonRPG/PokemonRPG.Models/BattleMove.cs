namespace PokemonRPG.Models;

public class BattleMove
{
    public int Id { get; set; }
    public MonsterType Type { get; set; }
    public string Name { get; set; }
    public int MaxPP { get; set; }
    public int CurrentPP { get; set; }
    public string Description { get; set; }
    public int Power { get; set; }
    public int Accuracy { get; set; }
    
}