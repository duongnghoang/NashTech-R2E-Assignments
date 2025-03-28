using System.Globalization;
using Day2.Constants;

namespace Day2.Utils;

/// <summary>
///     Handles input and output operations
/// </summary>
public static class InputUtils
{
    /// <summary>
    ///     Gets a valid string input from the user.
    /// </summary>
    /// <param name="message">The message to prompt the user.</param>
    /// <param name="invalidMessage">The message to display if the input is invalid.</param>
    /// <returns>A valid string input from the user.</returns>
    public static string GetUserStringInput(string message, string invalidMessage)
    {
        Console.Write(message);
        while (true)
        {
            var input = Console.ReadLine()?.Trim();
            if (ValidationUtils.IsValidString(input)) return input!;
            Console.WriteLine(invalidMessage);
            Console.Write(message);
        }
    }

    /// <summary>
    ///     Gets a valid year input from the user.
    /// </summary>
    /// <param name="message">The message to prompt the user.</param>
    /// <param name="invalidMessage">The message to display if the input is invalid.</param>
    /// <returns>A valid year input from the user.</returns>
    public static int GetUserYearInput(string message, string invalidMessage)
    {
        Console.Write(message);
        while (true)
        {
            var input = Console.ReadLine()?.Trim();
            if (ValidationUtils.IsValidYear(input)) return int.Parse(input!);
            Console.WriteLine(invalidMessage);
            Console.Write(message);
        }
    }

    /// <summary>
    ///     Gets a valid DateTime input from the user.
    /// </summary>
    /// <param name="message">The message to prompt the user.</param>
    /// <param name="dateFormat">The date format to validate the input against.</param>
    /// <returns>A valid DateTime input from the user.</returns>
    [Obsolete("Use GetUserDateTimeInput(string, string) instead.")]
    public static DateTime GetUserDateTimeInput(string message, string dateFormat)
    {
        Console.Write(message);
        while (true)
        {
            var input = Console.ReadLine()?.Trim();
            if (ValidationUtils.IsValidDate(input, dateFormat))
                return DateTime.ParseExact(input!, dateFormat,
                    CultureInfo.InvariantCulture, DateTimeStyles.AssumeUniversal);
            Console.WriteLine(ApplicationMessage.InvalidDateMessage(dateFormat));
            Console.Write(message);
        }
    }

    /// <summary>
    ///     Gets a valid DateTime input for maintenance from the user.
    /// </summary>
    /// <param name="message">The message to prompt the user.</param>
    /// <param name="dateFormat">The date format to validate the input against.</param>
    /// <param name="year">The year to validate the maintenance date against.</param>
    /// <returns>A valid DateTime input for maintenance from the user.</returns>
    public static DateTime GetUserMaintenanceDateInput(string message, string dateFormat, int year)
    {
        Console.Write(message);
        while (true)
        {
            var input = Console.ReadLine()?.Trim();
            if (!ValidationUtils.IsValidDate(input, dateFormat))
            {
                Console.WriteLine(ApplicationMessage.InvalidDateMessage(dateFormat));
                Console.Write(message);
                continue;
            }

            if (!ValidationUtils.IsValidDate(input, dateFormat, new DateTime(year, 1, 1), DateTime.UtcNow))
            {
                Console.WriteLine(
                    ApplicationMessage.InvalidMaintenanceDate(new DateTime(year, 1, 1), DateTime.UtcNow));
                Console.Write(message);
                continue;
            }

            return DateTime.ParseExact(input!, dateFormat,
                CultureInfo.InvariantCulture, DateTimeStyles.AssumeUniversal);
        }
    }

    /// <summary>
    ///     Gets a valid DateTime input from the user within a specified date range.
    /// </summary>
    /// <param name="message">The message to prompt the user.</param>
    /// <param name="invalidMessage">The message to display if the input is invalid.</param>
    /// <param name="dateFormat">The date format to validate the input against.</param>
    /// <param name="validStartDate">The start date of the valid range.</param>
    /// <param name="validEndDate">The end date of the valid range.</param>
    /// <returns>A valid DateTime input from the user within the specified date range.</returns>
    public static DateTime GetUserDateTimeInput(string message, string invalidMessage, string dateFormat,
        DateTime validStartDate, DateTime validEndDate)
    {
        Console.Write(message);
        while (true)
        {
            var input = Console.ReadLine()?.Trim();
            if (ValidationUtils.IsValidDate(input, dateFormat, validStartDate, validEndDate))
                return DateTime.ParseExact(input!, dateFormat,
                    CultureInfo.InvariantCulture, DateTimeStyles.AssumeUniversal);
            Console.WriteLine(invalidMessage);
            Console.Write(message);
        }
    }

    /// <summary>
    ///     Gets a valid choice input from the user.
    /// </summary>
    /// <param name="message">The message to prompt the user.</param>
    /// <param name="invalidMessage">The message to display if the input is invalid.</param>
    /// <param name="choices">The list of valid choices.</param>
    /// <returns>A valid choice input from the user.</returns>
    public static string GetUserChoice(string message, string invalidMessage, List<string> choices)
    {
        Console.Write(message);
        while (true)
        {
            var input = Console.ReadLine()?.Trim().ToUpper();
            if (ValidationUtils.IsValidChoice(input, choices)) return input!;
            Console.WriteLine(invalidMessage);
            Console.Write(message);
        }
    }
}