namespace ClassDemo;

class Staff
{
    #region Fields
//This is known as access modifier
    private string nameOfStaff;
    private const int hourlyRate = 30;
    private int hWorked;
    

    #endregion
    


    #region Properties
    public int HoursWorked
    {
        get => hWorked;
        set
        {
            if (value > 0)
                hWorked = value;
            else
            {
                hWorked = 0;
            }
        }
    }

    #endregion

    
    #region Methods
    public void PrintMessage()
    {
        Console.WriteLine("Calculating Pay");
    }

    public int CalculatePay()
    {
        PrintMessage();
        int staffPay;
        staffPay = hWorked * hourlyRate;
        
        if(hWorked > 0)
            return staffPay;
        else
        {
            return 0;
        }
    }

    public int CalculatePay(int bonus, int allowance)
    {
        PrintMessage();
        
        if(hWorked > 0)
            return hWorked * hourlyRate + bonus + allowance;
        else
        {
            return 0;
        }
            
    }
    

    
    public override string ToString()
    {
        return $"Name of Staff = {nameOfStaff}, hourlyRate = {hourlyRate}, hWorked = {hWorked}";
    }

    #endregion
    
    
    #region Constructors
    public Staff(string name)
    {
        nameOfStaff = name;
        Console.WriteLine("\n" + nameOfStaff);
        Console.WriteLine("---------------------------");
    }

    public Staff(string firstName, string lastName)
    {
        nameOfStaff = $"{firstName} {lastName}" ;
        Console.WriteLine("\n" + nameOfStaff);
        Console.WriteLine("---------------------------");
        
    }
    
    #endregion
}

class Program
{
    static void Main(string[] args)
    {
        // The syntax for instantiating an object is
        //     ClassName objectName = new ClassName(arguments);

        int pay;
        
        Staff Staff1 = new Staff("John");
        Staff1.HoursWorked = 160;
        pay = Staff1.CalculatePay(1000, 400);
        Console.WriteLine("Pay = {0}",pay);
         
        Staff Staff2 = new Staff("Jane","Lee");
        Staff2.HoursWorked = 160;
        pay = Staff2.CalculatePay();
        Console.WriteLine("Pay = {0}",pay);
        
        
        Staff Staff3 = new Staff("Carol", "Lee");
        Staff3.HoursWorked = -4000;
        pay = Staff3.CalculatePay();
        Console.WriteLine("Pay = {0}",pay);
        
    }

    
}