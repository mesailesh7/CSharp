namespace VirtualPetSimulator;
using static Console;

class Program
{
    static void Main(string[] args)
    {
        World myWorld = new World();
        myWorld.Run();
    }
}