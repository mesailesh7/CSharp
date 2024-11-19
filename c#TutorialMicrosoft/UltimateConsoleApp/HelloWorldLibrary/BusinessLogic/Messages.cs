using System.Text.Json;
using Microsoft.Extensions.Logging;

namespace HelloWorldLibrary.BusinessLogic;

public partial class Messages: IMessages
{
    
    private readonly ILogger<Messages> _log;
    
     public Messages(ILogger<Messages> log)
    {
        _log = log
    }

    public string Greeting(string language)
    {
        string output = LookUpCustomText("Greeting", language);
        return output;

    }

    private string LookUpCustomText(string key, string language)
    {
        JsonSerializerOptions options = new()
        {
            PropertyNameCaseInsensitive = true,
        };


        try
        {
            List<CustomText>? messagesSets = JsonSerializer.Deserialize<List<CustomTexT>>(
                File.ReadAllText("CustomText.json"),options
            );

            CustomText? messages = messagesSets?.Where(x => x.language == language).First();

            if (messages is null)
            {
                throw new NullReferenceException("The specified language was not found in the json file");
            }

            return messages.Translatinos[key];

        }
        catch (Exception e)
        {
            _log.LogError($"Error looking up the custom text {ex}");
            throw;
        }
        

    }
}