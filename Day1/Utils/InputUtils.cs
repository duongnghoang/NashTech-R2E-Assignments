namespace Day1.Utils;

/// <summary>
/// Handles input and output operations
/// </summary>
public static class InputUtils
{
    /// <summary>
    /// Handles input and output for string-type input
    /// User is required to input string until valid
    /// </summary>
    /// <param name="message">Represent title input request message to console</param>
    /// <param name="invalidMessage">Represent input invalid message (currently 1)</param>
    /// <returns>The string value of user input</returns>
    public static string GetUserStringInput(string message, string invalidMessage)
    {
        Console.WriteLine(message);
        while (true)
        {
            string? input = Console.ReadLine();
            if (!string.IsNullOrEmpty(input))
            {
                return input;
            }
            Console.WriteLine(invalidMessage);
        }
    }

    /// <summary>
    /// Handles input and output for integer-type input
    /// User is required to input string until valid
    /// </summary>
    /// <param name="message">Represent title input request message to console</param>
    /// <param name="invalidMessage">Represent input invalid message (currently 1)</param>
    /// <returns>The integer value of user input</returns>
    public static int GetUserIntInput(string message, string invalidMessage)
    {
        Console.WriteLine(message);
        string? input = Console.ReadLine();
        int number;
        while (!int.TryParse(input, out number))
        {
            Console.WriteLine(invalidMessage);
            input = Console.ReadLine();
            
        }
        return number;
    }

    /// <summary>
    /// Handles input and output for year input
    /// User is required to input string until valid
    /// </summary>
    /// <param name="message">Represent title input request message to console</param>
    /// <param name="invalidMessage">Represent input invalid message (currently 1)</param>
    /// <returns>The year value of user input</returns>
    public static int GetUserYearInput(string message, string invalidMessage)
    {
        Console.WriteLine(message);
        string? input = Console.ReadLine();
        var currentYear = DateTime.UtcNow.Year;
        int number;
        while (!int.TryParse(input, out number) || number > currentYear || number <= 1900)
        {
            Console.WriteLine(invalidMessage);
            input = Console.ReadLine();
        }
        return number;
    }

    /// <summary>
    /// Handles input and output for enum-type input
    /// User is required to input string until valid
    /// </summary>
    /// <typeparam name="TEnum">The enum type to be parsed</typeparam>
    /// <param name="message">Represents the title input request message to console</param>
    /// <param name="invalidMessage">Represents the input invalid message</param>
    /// <returns>The parsed enum value of type TEnum</returns>
    public static TEnum GetUserEnumInput<TEnum>(string message, string invalidMessage) where TEnum : struct
    {
        Console.WriteLine(message);
        string? input = Console.ReadLine();
        TEnum resultEnum;
        while (!Enum.TryParse(input, true, out resultEnum) || !Enum.IsDefined(typeof(TEnum), input))
        {
            Console.WriteLine(invalidMessage);
            input = Console.ReadLine();
        }

        return resultEnum;
    }
}