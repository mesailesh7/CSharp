using System.ComponentModel;
using System.Xml;
using static System.Console;


namespace InheritanceGameDemo;

public class Anaconda: Character
{
    private double _chargeDistance;
    private Item CurrentItem;
    
    
    private double ChargeDistance{get => _chargeDistance; set => _chargeDistance = value;}


    public Anaconda(string name, int health, ConsoleColor color, int chargeDistance) : base(name, health, color, ArtAssets
        .Anaconda)
    {
        ChargeDistance = chargeDistance;
        TextArt = ArtAssets.Anaconda;
    }


    public void Charge()
    {
        BackgroundColor = Color;
        Write($"{Name} is charging.");
        ResetColor();
        WriteLine($"charges swiftly forward {ChargeDistance} inchces");


        if (CurrentItem != null)
        {
            WriteLine($"They are carrying a {CurrentItem.Name}");
        }
    }


    public void Bite()
    {
        BackgroundColor = Color;
        Write($"{Name}");
        ResetColor();
        WriteLine(" viciously poisionous bite");
    }
    
    


}