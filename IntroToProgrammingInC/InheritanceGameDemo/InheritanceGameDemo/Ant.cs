using System.Drawing;
namespace InheritanceGameDemo;
using static System.Console;
public class Ant : Character
{
    private double _chargeDistance;
    private Item CurrentItem;

    
    #region Properties
    
    private double ChargeDistance { get => _chargeDistance; set => _chargeDistance = value; }
    #endregion

    public Ant(string name, int health, ConsoleColor color, int chargeDistance):base(name,health,color,ArtAssets.Ant  )
    {
        
        ChargeDistance = chargeDistance;
        TextArt = ArtAssets.Ant;       

    }

    public void PickUpItem(Item item)
    {
        CurrentItem = item;
    }

    

    public void Charge()
    {
        BackgroundColor = Color;
        Write($"{Name} ");
        ResetColor();
        WriteLine($"charges swiftly forward {ChargeDistance} inches");

        if (CurrentItem !=  null)
        {
            WriteLine($"They are carrying a {CurrentItem.Name}");
        }
        
        
    }

    public void Bite()
    {
        BackgroundColor = Color;
        Write($"{Name} ");
        ResetColor();
        WriteLine(" viciously chomps down!");
    }

    public override void Fight(Character otherCharacter)
    {
        ForegroundColor = Color;
        WriteLine($"Ant {Name} is fighting ");
        ResetColor();
        int randNum = RandGenerator.Next(1, 101);
        if(randNum <= 50) Charge();
        else Bite();
            
    }

}