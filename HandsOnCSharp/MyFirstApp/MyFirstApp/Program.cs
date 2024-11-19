namespace MyFirstApp;

class Program
{
    static void Main(string[] args)
    {
        int balance, depostAmt, withdrawAmt;
        int choice = 0, pin = 0;
        Console.WriteLine("Enter your ledger balance");
        balance = int.Parse(Console.ReadLine());
        Console.WriteLine("Enter your pin number");
        pin = int.Parse(Console.ReadLine());

        if (pin != 1234)
        {
            Console.WriteLine("Invalid pin number");
            Console.ReadKey(false);
            return;
        }

        while (choice != 4)
        {
            Console.WriteLine("********** Welcome to PACKT Payment Bank *********\n");
            Console.WriteLine("1. Check Balance");
            Console.WriteLine("2. Withdraw Cash");
            Console.WriteLine("3. Depost Cash");
            Console.WriteLine("4. Quit");
            Console.WriteLine("******** *******");
            Console.WriteLine("Enter your choice");
            choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Console.WriteLine("Please enter your deposit amount");
                    break;
                case 2:
                    Console.WriteLine("Please enter your withdraw amount");
                    withdrawAmt = int.Parse(Console.ReadLine());
                    if(withdrawAmt > balance)
                    break;
                case 3:
                    
            }
            
            
        }
    }
}