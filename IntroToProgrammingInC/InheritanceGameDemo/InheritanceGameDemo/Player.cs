namespace InheritanceGameDemo;

public class Player: Character
{
    public Player(string name, int health, ConsoleColor color) : base(name, health, color, ArtAssets.Player)
    {
        
    }

    public override void Fight(Character otherCharacter)
    {
        
    }
}