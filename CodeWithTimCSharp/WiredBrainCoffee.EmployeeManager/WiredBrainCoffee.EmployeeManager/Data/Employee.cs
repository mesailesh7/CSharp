using System.ComponentModel.DataAnnotations;

namespace WiredBrainCoffee.EmployeeManager.Data;

public class Employee
{
    public int Id { get; set; }
    
    [Required]
    [StringLength(50)]
    public string? FirstName { get; set; }
    
    [Required]
    [StringLength(50)]
    public string? LastName { get; set; }
    
    [Required]
    public bool IsDeveloper { get; set; }
    
    
    
}