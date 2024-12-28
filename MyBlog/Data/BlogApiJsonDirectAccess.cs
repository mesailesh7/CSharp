using Data.Models.Interfaces;
using Microsoft.Extensions.Options;
using System.Text.Json;
using Data.Models;

namespace Data;

public class BlogApiJsonDirectAccess : IBlogApi
{
    private _BlogApiJsonDirectAccessSetting _settings;

    public BlogApiJsonDirectAccess(IOptions<BlogApiJsonDirectAccessSetting> option)
    {
        _settings = option.Value;
        ManageDataPaths();
    }

    private void ManageDataPaths()
    {
        CreateDirectoryIfNotExists(_settings.DataPath);
        CreateDirectoryIfNotExists($@"{_settings.DataPath}\{_settings.BlogPostsFolder}");
        CreateDirectoryIfNotExists($@"{_settings.DataPath}\{_settings.CategoriesFolder}");
        CreateDirectoryIfNotExists($@"{_settings.DataPath}\{_settings.TagsFolder}");
        CreateDirectoryIfNotExists($@"{_settings.DataPath}\{_settings.CommentsFolder}");
    }

    private static void CreateDirectoryIfNotExists(string path)
    {
        if (!Directory.Exists(path))
        {
            Directory.CreateDirectory(path);
        }
    }

    private async Task<List<T>> LoadAsync<T>(string folder)
    {
        var list = new List<T>();
        foreach (var f in Directory.GetFiles($@"{_settings.DataPath}\{folder}"))
        {
            var json = await File.ReadAllTextAsync(f);
            var blogPost = JsonSerializer.Deserialize<T>(json);
            if (blogPost is not null)
            {
                list.Add(blogPost);
            }
        }
        return list;
    }

    private async Task SaveAsync<T>(string folder, string filename, T item)
    {
        var filepath = $@"{_settings.DataPath}/{folder}\{filename}.json";
        await File.WriteAllTextAsync(filepath, JsonSerializer.Serialize<T>(item));

        private Task DeleteAsync(string folder, string filename)
        {
            var filepath = $@"{_settings.DataPath}\{folder}\{filename}.json";
            if (File.Exists(filepath))
            {
                File.Delete(filepath);
            }
            return Task.CompletedTask;
        }
    }
}