using SimpleBookCatalog.Domain.Enums;

namespace SimpleBookCatalog.Domain.Entities;

public class Book
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Author { get; set; }
    public DateTime PublishDate { get; set; }
    public Category Category { get; set; }
}