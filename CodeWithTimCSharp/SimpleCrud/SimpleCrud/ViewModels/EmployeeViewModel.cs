using System.ComponentModel.DataAnnotations;

namespace SimpleCrud.ViewModels;

public class EmployeeViewModel
{
    // [Key] if you Id behing name like EmployeeId entity framework will automatically take it as primary key. other wise put [Key] and that will make it a primary key
    
    
    public int EmployeeId { get; set; }

    public string EmployeeIdView
    {
        get
        {
            return "EMP" + EmployeeId.ToString().PadLeft(4, '0');
        }
    }

    [Required]
    public string FullName { get; set; }
    [Required]
    public string Department { get; set; }
    [Required]
    public DateTime DateOfBirth { get; set; }
    [Required]
    public int Age { get; set; }
    [Required]
    public string PhoneNumber { get; set; }   
}