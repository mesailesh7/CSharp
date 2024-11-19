namespace TutorialProjectOOP;

class Program
{
    static void Main(string[] args)
    {
        string[] file = ReadFile("values.csv");
        List<Person> people = new List<Person>();
        
        people = GetPeople(file);
        
        

    }

    /// <summary>
    /// Read from file and return lines
    /// </summary>
    /// <param name="fileName">Path to file</param>
    /// <returns>String array of file lines</returns>
    static string[] ReadFile(string fileName)
    {
        string[] lines = System.IO.File.ReadAllLines(fileName);
        return lines;
    }

    /// <summary>
    /// Get people from file
    /// </summary>
    /// <param name="file">File lines</param>
    /// <returns>List of People</returns>
    static List<Person> GetPeople(string[] file)
    {
               
    }
    
}