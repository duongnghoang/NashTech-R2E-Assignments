using Day2.Constants;
using System.Globalization;
using Day2.Entities;

namespace Day2.Utils
{
    /// <summary>
    /// Handles input and output operations
    /// </summary>
    public static class InputUtils
    {
        public static string GetUserStringInput(string message, string invalidMessage)
        {
            Console.Write(message);
            while (true)
            {
                string? input = Console.ReadLine()?.Trim();
                if (ValidationUtils.IsValidString(input))
                {
                    return input!;
                }
                Console.WriteLine(invalidMessage);
                Console.Write(message);
            }
        }

        public static int GetUserYearInput(string message, string invalidMessage)
        {
            Console.Write(message);
            while (true)
            {
                string? input = Console.ReadLine()?.Trim();
                if (ValidationUtils.IsValidYear(input))
                {
                    return int.Parse(input!);
                }
                Console.WriteLine(invalidMessage);
                Console.Write(message);
            }
        }

        public static DateTime GetUserDateTimeInput(string message, string dateFormat)
        {
            Console.Write(message);
            while (true)
            {
                string? input = Console.ReadLine()?.Trim();
                if (ValidationUtils.IsValidDate(input, dateFormat))
                {
                    return DateTime.ParseExact(input!, dateFormat, 
                        CultureInfo.InvariantCulture, DateTimeStyles.AssumeUniversal);
                }
                Console.WriteLine(ApplicationMessage.InvalidDateMessage(dateFormat));
                Console.Write(message);
            }
        }

        public static DateTime GetUserDateTimeInput(string message, string dateFormat, 
            DateTime validStartDate, DateTime validEndDate)
        {
            Console.WriteLine(message);
            while (true)
            {
                string? input = Console.ReadLine()?.Trim();
                if (ValidationUtils.IsValidDate(input, dateFormat, validStartDate, validEndDate))
                {
                    return DateTime.ParseExact(input!, dateFormat, 
                        CultureInfo.InvariantCulture, DateTimeStyles.AssumeUniversal);
                }
                Console.WriteLine(ApplicationMessage.InvalidDateMessage(dateFormat));
                Console.Write(message);
            }
        }

        public static string GetUserChoice(string message, string invalidMessage, List<string> choices)
        {
            Console.WriteLine(message);
            while (true)
            {
                string? input = Console.ReadLine()?.Trim().ToUpper();
                if (ValidationUtils.IsValidChoice(input, choices))
                {
                    return input!;
                }
                Console.WriteLine(invalidMessage);
                Console.Write(message);
            }
        }
    }
}