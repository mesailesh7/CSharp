namespace VirtualPetSimulator;
using static Console;
public class World
{
    public void Run()
    {
        Title = "===Virtual Pet Simulator===";
        WriteLine(@"                                                                                                                                                                                          
 _  _  __  ____  ____  _  _   __   __      ____  ____  ____ 
/ )( \(  )(  _ \(_  _)/ )( \ / _\ (  )    (  _ \(  __)(_  _)
\ \/ / )(  )   /  )(  ) \/ (/    \/ (_/\   ) __/ ) _)   )(  
 \__/ (__)(__\_) (__) \____/\_/\_/\____/  (__)  (____) (__) 
");
        WriteLine("Welcome to the pet simulator");
        //Virtual pet is  a new type
        // leo is identifier
        // new Virtualpet() constructs a Virtualpet object
        VirtualPet leoTheCat = new VirtualPet("leo",12,"Cat",true);
        //As soon as you provide a constructor you don't need the below code
        // leoTheCat.FullName = "Leo";
        // leoTheCat.Age = 50;
        // leoTheCat.Species = "Cat";
        // leoTheCat.IsAwake = true;
        //This will cause error because ExperiencePoints id private;
        // leoTheCat.ExperiencePoints = 10;
        

        WriteLine("> Pet 1");
        leoTheCat.Greet();//Invoke a method
        leoTheCat.Eat("Cat Food");
        
        WriteLine();
        WriteLine();

            
        
        VirtualPet juniorTheParrot = new VirtualPet("Junior",12,"Parrot",false);
        // juniorTheParrot.FullName = "Junior";
        // juniorTheParrot.Age = 12;
        // juniorTheParrot.Species = "Parrot";
        // juniorTheParrot.IsAwake = false;
        WriteLine("> Pet 2");
        juniorTheParrot.Greet();
        juniorTheParrot.Eat("Worm");
        juniorTheParrot.SLeep();
        WriteLine();

        
        VirtualPet callieTheUnicorn = new VirtualPet("Callie",250,"Unicorn",true);
        callieTheUnicorn.Greet();
        callieTheUnicorn.Eat("Rainbows");

        WriteLine("Press any key to exit.....");
        // ReadKey();                
    }
}