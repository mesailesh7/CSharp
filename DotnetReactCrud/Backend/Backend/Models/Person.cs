using System;
using System.ComponentModel.DataAnnotations;

namespace Backend.Models;

public class Person
{
    //once you put id it will automatically choosen as primary key 
    public int Id { get; set; }
    [Required]
    [MaxLength(30)]
    public string FirstName { get; set; } = string.Empty;
    [Required]
    [MaxLength(30)]
    public string LastName { get; set; } = string.Empty;
}
