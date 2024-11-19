using static System.Console;

namespace InheritanceGameDemo;

public class Bee : Character
{
    
    
    private bool _hasPoisonSting;
    

    private bool HaspoisonSting
    {
        get => _hasPoisonSting;
        set => _hasPoisonSting = value;
    }

    public Bee(string name, int health, ConsoleColor color, bool hasPoison) : base(name, health, color, ArtAssets.Bee)
    {
        HaspoisonSting = hasPoison;
        RandGenerator = new Random();
    }


    public void FLy()
    {
        BackgroundColor = Color;
        Write($"{Name}");
        ResetColor();
        WriteLine($"Takes to the air!");
    }

    public void Sting()
    {
        BackgroundColor = Color;
        Write($"{Name} ");
        ResetColor();
        Write($"lunges forward with their");
        if(HaspoisonSting) WriteLine("poison stinger");
        else WriteLine("Sharp sting");
        
    }
    
    public override void Fight(Character otherCharacter)
    {
        ForegroundColor = Color;
        WriteLine($"Ant {Name} is fighting ");
        ResetColor();
        int randNum = RandGenerator.Next(1,101);
        if(randNum <= 50) FLy();
        else Sting();            
    }
}