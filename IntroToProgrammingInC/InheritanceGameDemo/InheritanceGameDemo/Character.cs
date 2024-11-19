namespace InheritanceGameDemo;
using static System.Console;


public class Character
{
    private string _name;
    private int _health;
    private string _textArt;
    private ConsoleColor _color;
    protected Random RandGenerator;
    
    #region Properties

    protected string Name { get => _name; set => _name = value; }
    protected int Health { get => _health; set => _health = value; }
    protected string TextArt { get => _textArt; set => _textArt = value; }
    protected ConsoleColor Color { get => _color; set => _color = value; }
    // private double ChargeDistance { get => _chargeDistance; set => _chargeDistance = value; }
    #endregion

    public Character(string name, int health, ConsoleColor color, string textArt)
    {
        Name = name;
        Health = health;
        Color = color;
        TextArt = textArt;
        RandGenerator = new Random();
    }

    public void DisplayInfo()
    {
        ForegroundColor = Color;
        WriteLine($"--- {Name} ---");
        WriteLine($"\n {TextArt} \n");
        WriteLine($"Health: {Health}\n");
        ResetColor();        
    }

    public virtual void Fight( Character otherCharacter )
    {
        WriteLine("Character is fighting");
    }

}