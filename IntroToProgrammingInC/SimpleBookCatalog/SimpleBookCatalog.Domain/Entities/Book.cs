using System.ComponentModel.DataAnnotations;
using SimpleBookCatalog.Domain.Enums;

namespace SimpleBookCatalog.Domain.Entities;

public class Book
{
    public int Id { get; set; }
    [Required]
    [StringLength(100)]
    public string? Title { get; set; }
    [Required]
    [StringLength(100)]
    public string? Author { get; set; }
    public DateTime? PublicationDate { get; set; }
    public Category Category { get; set; }
    
    
}