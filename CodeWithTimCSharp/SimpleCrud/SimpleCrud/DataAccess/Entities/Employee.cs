using System.ComponentModel.DataAnnotations;

namespace SimpleCrud.DataAccess.Entities;

public class Employee
{
    // [Key] if you Id behing name like EmployeeId entity framework will automatically take it as primary key. other wise put [Key] and that will make it a primary key
    
    public int EmployeeId { get; set; }
    public string FullName { get; set; }
    public string Department { get; set; }
    public DateTime DateOfBirth { get; set; }
    public int Age { get; set; }
    public string PhoneNumber { get; set; }
    
}