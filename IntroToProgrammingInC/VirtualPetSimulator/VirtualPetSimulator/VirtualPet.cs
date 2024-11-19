namespace VirtualPetSimulator;
using static Console;
public class VirtualPet
{
    //Field
    // public is a acess modifier
    //string type
    //Name = identifier
    public string FullName = "";
    public int Age;
    public string Species = "";
    public bool IsAwake;
    private int ExperiencePoints;

    //Constructor: No return type and same name as the class
    public VirtualPet(string petName, int petAge, string petSpecies, bool petIsAwake)
    {
        // WriteLine("Pet being constructed");
        FullName = petName;
        Age = petAge;
        Species = petSpecies;
        IsAwake = petIsAwake;
        
    }

    
    //Method Defination
    //public can be accessed from the same namespace but private can be accessed from the same class only
    //void which doesn't have any return
    public void Greet()
    {
        WriteLine($"My name is {FullName} and I am {Age} years old. My Species is {Species}."); 
        WriteLine($"{IsAwake}");
    }

    public void SLeep()
    {
        IsAwake = false;
        WriteLine($"{FullName} is now sleeping happily.....zzzzz");
    }

    //One input (Aka a parameter)
    public void Eat(string foodName)
    {
        WriteLine($"{FullName} is eating {foodName}");
    }



}