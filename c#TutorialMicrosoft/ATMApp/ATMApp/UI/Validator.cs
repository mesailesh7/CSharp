using System.ComponentModel;

namespace ATMApp.UI;

public static class Validator
{
    public static T Convert(T)(string prompt)
    {
        bool valid = false;
        string userInput = "";


        while (!valid)
        {
            userInput = Utility.GetUserInput(prompt);

            try
            {
                TypeDescriptor.GetConverter()
            }
        }
    }
        
}