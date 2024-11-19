using System.Text;

namespace MySuperBank;

public class BankAccount
{
    public string Number { get; }
    public string Owner { get; set; }

    public decimal Balance
    {
        get
        {
            decimal balance = 0;
            foreach (var item in allTransactions)
            {
                balance += item.Amount;
                // balance -+ item.Amount;
            }

            return balance;
        }
    }


    private static int accountNumberSeed = 1234567890;


    private List<Transaction> allTransactions = new List<Transaction>();

    //Bank account constructor
    public BankAccount(string name, decimal initialBalance)
    {
        this.Owner = name;
        // this.Balance = initialBalance;

        MakeDeposit(initialBalance, DateTime.Now, "Initial deposit");
        this.Number = accountNumberSeed.ToString();
        accountNumberSeed++;
    }


    public void MakeDeposit(decimal amount, DateTime date, string note)
    {
        if (amount <= 0l)
        {
            throw new ArgumentOutOfRangeException(nameof(amount), "Amount of withdrawl must be positive");
        }

        var deposit = new Transaction(amount, date, note);
        allTransactions.Add(deposit);
    }

    public void MakeWithDrawal(decimal amount, DateTime date, string note)
    {
        if (amount <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(amount), "Amount of withdrawl must be positive");
        }

        if (Balance - amount < 0)
        {
            throw new InvalidOperationException("not sufficient funds for this withdrawl");
            ;
        }

        var withdrawal = new Transaction(-amount, date, note);
        allTransactions.Add(withdrawal);
    }

    public string GetAccountHistory()
    {
        var report = new StringBuilder();
        //Header
        report.AppendLine("Date\t\tAmount\tNote");
        foreach (var item in allTransactions)
        {
            //Rows
            report.AppendLine($"{item.Date.ToShortDateString()}\t{item.Amount}\t{item.Notes}");
        }

        return report.ToString();
    }
}