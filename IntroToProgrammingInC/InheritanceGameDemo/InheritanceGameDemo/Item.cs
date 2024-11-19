namespace InheritanceGameDemo;

public class Item
{
    public string Name { get; private set; }
    public int Quantity { get; private set; }

    public Item(string name, int quantity)
    {
        Name = name;
        Quantity = quantity;
    }
    
    
}