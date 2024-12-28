namespace Data.Models;

public class BlogPost
{
    
    // this class, we define the content of our blog post. We need an Id to identify the blog post, a title, some text (the article), and the publishing date. We also have a Category property in the class, which is of the Category type. In this case, a blog post can have only one category, and a blog post can contain zero or more tags. We define the Tag property with List<Tag>.”
    
    public string? Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Text { get; set; } = string.Empty;
    public DateTime PublishDate { get; set; }
    public Category? Category { get; set; }
    public List<Tag> Tags { get; set; } = new();
}