namespace List
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> shoppingList = new List<string>
            {
                "chocolate",
                "banana",
                "sugar",
                "milk",
                "cereal"
            };

            shoppingList.Add("Lemon");
            shoppingList.Add("Apple");

            foreach (string shop in shoppingList)
            {
                Console.WriteLine(shop);
            }
        }
    }
}
