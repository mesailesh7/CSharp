namespace MySuperBank;

class Program
{
    static void Main(string[] args)
    {
        var account = new BankAccount(
            "Kendra",
            10000
        );
        Console.WriteLine($"Account {account.Number} was created for {account.Owner} with {account.Balance}");

        account.MakeWithDrawal(120, DateTime.Now, "hammock");


        account.MakeWithDrawal(50, DateTime.Now, "Xbox Game");


        Console.WriteLine(account.GetAccountHistory());


        //Test that the initial balances must be positive.
        // try
        // {
        //     var invalidAccount = new BankAccount("invalid", -55);
        // }
        // catch (ArgumentOutOfRangeException e)
        // {
        //     Console.WriteLine("Exception caught creating account with negative balance");
        //     Console.WriteLine(e.ToString());
        // }
        //
        //
        // //test for negative balance;
        // try
        // {
        //     account.MakeWithDrawal(7500, DateTime.Now, "attempt ot overdraw");
        // }
        // catch (InvalidOperationException e)
        // {
        //     Console.WriteLine("exception caught trying to overdraw");
        //     Console.WriteLine(e.ToString());
        // }
    }
}