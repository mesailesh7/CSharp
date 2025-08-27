using ExampleMudSystem.DAL;

namespace ExampleMudSystem.BLL;

public class EmployeeService
{
    private readonly OLTPDMIT2018Context _hogWildContext;

    internal EmployeeService(OLTPDMIT2018Context hogWildContext)
    {
        _hogWildContext = hogWildContext;
    }
    
    public string GetEmployeeFullName(int employeeID)
    {
        return _hogWildContext.Employees
                   .Where(x => x.EmployeeID == employeeID
                               && !x.RemoveFromViewFlag)
                   .Select(x => $"{x.FirstName} {x.LastName}")
                   .FirstOrDefault()
               ?? string.Empty;
    }
}