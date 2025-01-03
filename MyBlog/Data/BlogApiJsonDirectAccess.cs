using Data.Models.Interfaces; // Importing the interface for the blog API
using Microsoft.Extensions.Options; // Importing for using options pattern with settings
using System.Text.Json; // Importing for JSON serialization and deserialization
using Data.Models; // Importing the data models

namespace Data; // Defining the namespace

public class BlogApiJsonDirectAccess : IBlogApi // Class implementing the IBlogApi interface
{
    private _BlogApiJsonDirectAccessSetting _settings; // Private field to store the settings

    public BlogApiJsonDirectAccess(IOptions<BlogApiJsonDirectAccessSetting> option) // Constructor taking options for settings
    {
        _settings = option.Value; // Assigning the settings value from options
        ManageDataPaths(); // Calling a method to manage data paths
    }

    private void ManageDataPaths() // Method to create directories if they don't exist
    {
        CreateDirectoryIfNotExists(_settings.DataPath); // Creating the main data directory
        CreateDirectoryIfNotExists($@"{_settings.DataPath}\{_settings.BlogPostsFolder}"); // Creating the blog posts directory
        CreateDirectoryIfNotExists($@"{_settings.DataPath}\{_settings.CategoriesFolder}"); // Creating the categories directory
        CreateDirectoryIfNotExists($@"{_settings.DataPath}\{_settings.TagsFolder}"); // Creating the tags directory
        CreateDirectoryIfNotExists($@"{_settings.DataPath}\{_settings.CommentsFolder}"); // Creating the comments directory
    }

    private static void CreateDirectoryIfNotExists(string path) // Method to create a directory if it doesn't exist
    {
        if (!Directory.Exists(path)) // Checking if the directory exists
        {
            Directory.CreateDirectory(path); // Creating the directory
        }
    }
    
    
    private async Task<List<T>> LoadAsync<T>(string folder) // Generic method to load data from JSON files in a folder
    {
        var list = new List<T>(); // Creating a new list of type T
        foreach (var f in Directory.GetFiles($@"{_settings.DataPath}\{folder}")) // Looping through each file in the specified folder
        {
            var json = await File.ReadAllTextAsync(f); // Reading the JSON content of the file
            var blogPost = JsonSerializer.Deserialize<T>(json); // Deserializing the JSON content into an object of type T
            if (blogPost is not null) // Checking if deserialization was successful
            {
                list.Add(blogPost); // Adding the deserialized object to the list
            }
        }

        return list; // Returning the list of deserialized objects
    }

    private async Task SaveAsync<T>(string folder, string filename, T item) // Generic method to save data to a JSON file
    {
        var filepath = $@"{_settings.DataPath}\{folder}\{filename}.json"; // Constructing the file path
        await File.WriteAllTextAsync(filepath, JsonSerializer.Serialize<T>(item)); // Serializing the object to JSON and writing it to the file

        private Task DeleteAsync(string folder, string filename) //Method to delete a JSON file
        {
            var filepath = $@"{_settings.DataPath}\{folder}\{filename}.json"; // Constructing the file path
            if (File.Exists(filepath)) // Checking if the file exists
            {
                File.Delete(filepath); // Deleting the file
            }
            return Task.CompletedTask; // Returning a completed task
        }
    }

    public async Task<int> GetBlogPostCountAsync() // Method to get the count of blog posts
    {
        var list = await LoadAsync<BlogPost>(
            _settings.BlogPostsFolder); // Loading the blog posts from the specified folder
        return list.Count; // Returning the count of blog posts
    }

    public async Task<List<BlogPost>> GetBlogPostsAsync(int numberofposts, int startindex) // Method to get a list of blog posts with paging
    {
        var list = await LoadAsync<BlogPost>(_settings.BlogPostsFolder); // Loading the blog posts from the specified folder
        return list.Skip(startindex).Take(numberofposts).ToList(); // Returning a paged list of blog posts
    }

    public async Task<BlogPost?> GetBlogPostAsync(string id) // Method to get a specific blog post by ID
    {
        var list = await LoadAsync<BlogPost>(_settings.BlogPostsFolder); // Loading the blog posts from the specified folder
        return list.FirstOrDefault(bp => bp.Id == id); // Returning the blog post with the matching ID
    }

    public async Task<List<Category>> GetCategoriesAsync() // Method to get all categories
    {
        return await LoadAsync<Category>(_settings.CategoriesFolder); // Loading the categories from the specified folder
    }

    public async Task<Category?> GetCategoryAsync(string id) // Method to get a specific category by ID
    {
        var list = await LoadAsync<Category>(_settings.CategoriesFolder); // Loading the categories from the specified folder
        return list.FirstOrDefault(c => c.Id == id); // Returning the category with the matching ID
    }

    public async Task<List<Tag>> GetTagsAsync() // Method to get all tags
    {
        return await LoadAsync<Tag>(_settings.TagsFolder); // Loading the tags from the specified folder
    }

    public async Task<Tag?> GetTagAsync(string id) // Method to get a specific tag by ID
    {
        var list = await LoadAsync<Tag>(_settings.TagsFolder); // Loading the tags from the specified folder
        return list.FirstOrDefault(t => t.Id == id); // Returning the tag with the matching ID
    }

    public async Task<List<Comment>> GetCommentsAsync(string blogPostId) // Method to get all comments for a specific blog post
    {
        var list = await LoadAsync<Comment>(_settings.CommentsFolder); // Loading the comments from the specified folder
        return list.Where(c => c.BlogPostId == blogPostId).ToList(); // Returning the comments with the matching blog post ID
    }


    public async Task<BlogPost?> SaveBlogPostAsync(BlogPost item) // Method to save a blog post
    {
        item.Id ??= Guid.NewGuid().ToString(); // Generating a new GUID for the ID if it's null
        await SaveAsync(_settings.BlogPostsFolder, item.Id, item); // Saving the blog post to the specified folder
        return item; // Returning the saved blog post
    }

    public async Task<Category?> SaveCategoryAsync(Category item) // Method to save a category
    {
        item.Id ??= Guid.NewGuid().ToString(); // Generating a new GUID for the ID if it's null
        await SaveAsync(_settings.CategoriesFolder, item.Id, item); // Saving the category to the specified folder
        return item; // Returning the saved category
    }

    public async Task<Tag?> SaveTagAsync(Tag item) // Method to save a tag
    {
        item.Id ??= Guid.NewGuid().ToString(); // Generating a new GUID for the ID if it's null
        await SaveAsync(_settings.TagsFolder, item.Id, item); // Saving the tag to the specified folder
        return item; // Returning the saved tag
    }

    public async Task<Comment?> SaveCommentAsync(Comment item) // Method to save a comment
    {
        item.Id ??= Guid.NewGuid().ToString(); // Generating a new GUID for the ID if it's null
        await SaveAsync(_settings.CommentsFolder, item.Id, item); // Saving the comment to the specified folder
        return item; // Returning the saved comment
    }

    public async Task DeleteBlogPostAsync(string id) // Method to delete a blog post and its associated comments
    {
        await DeleteAsync(_settings.BlogPostsFolder, id); // Deleting the blog post from the specified folder

        var comments = await GetCommentsAsync(id); // Getting all comments associated with the blog post
        foreach (var comment in comments) // Looping through each comment
        {
            if (comment.Id != null) // Checking if the comment has an ID
            {
                await DeleteAsync(_settings.CommentsFolder, comment.Id); // Deleting the comment from the specified folder
            }
        }
    }

    public async Task DeleteCategoryAsync(string id) // Method to delete a category
    {
        await DeleteAsync(_settings.CategoriesFolder, id); // Deleting the category from the specified folder
    }

    public async Task DeleteTagAsync(string id) // Method to delete a tag
    {
        await DeleteAsync(_settings.TagsFolder, id); // Deleting the tag from the specified folder
    }

    public async Task DeleteCommentAsync(string id) // Method to delete a comment
    {
        await DeleteAsync(_settings.CommentsFolder, id); // Deleting the comment from the specified folder
    }
    
}
