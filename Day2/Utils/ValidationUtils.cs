using System.Globalization;

namespace Day2.Utils;

public static class ValidationUtils
{
    public static bool IsValidString(string? input) 
        => !string.IsNullOrEmpty(input);

    public static bool IsValidYear(string? input)
    {
        var currentYear = DateTime.UtcNow.Year;
        if (int.TryParse(input, out int year))
        {
            return year > 1900 && year <= currentYear;
        }
        return false;
    }

    public static bool IsValidDate(string? input, string dateFormat) 
        => DateTime.TryParseExact(input, dateFormat, CultureInfo.InvariantCulture, 
            DateTimeStyles.AssumeUniversal, out var date)
            && DateTime.Compare(DateTime.UtcNow, date) >= 0;

    public static bool IsValidDate(string? input, string dateFormat, 
        DateTime validStartDate, DateTime validEndDate)
        => DateTime.TryParseExact(input, dateFormat, CultureInfo.InvariantCulture, 
               DateTimeStyles.AssumeUniversal, out DateTime date)
            && DateTime.Compare(validStartDate, date) <= 0 
            && DateTime.Compare(validEndDate, date) >= 0;

    public static bool IsValidChoice(string? input, List<string> choice) 
        => !string.IsNullOrEmpty(input) && choice.Contains(input);
}