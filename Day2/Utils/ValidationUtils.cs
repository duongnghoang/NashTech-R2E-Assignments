using System.Globalization;

namespace Day2.Utils;

/// <summary>
///     Contains validation methods for user inputs.
/// </summary>
public static class ValidationUtils
{
    /// <summary>
    /// Validates if the input is a non-empty string.
    /// </summary>
    /// <param name="input">The input string to validate.</param>
    /// <returns>True if the input is a valid string; otherwise, false.</returns>
    public static bool IsValidString(string? input)
        => !string.IsNullOrEmpty(input);

    /// <summary>
    /// Validates if the input is a valid year.
    /// </summary>
    /// <param name="input">The input string to validate.</param>
    /// <returns>True if the input is a valid year until now; otherwise, false.</returns>
    public static bool IsValidYear(string? input)
    {
        var currentYear = DateTime.UtcNow.Year;
        if (int.TryParse(input, out int year))
        {
            return year > 1900 && year <= currentYear;
        }
        return false;
    }

    /// <summary>
    /// Validates if the input is a valid date in the specified format.
    /// </summary>
    /// <param name="input">The input string to validate.</param>
    /// <param name="dateFormat">The date format to validate the input against.</param>
    /// <returns>True if the input is a valid date; otherwise, false.</returns>
    public static bool IsValidDate(string? input, string dateFormat)
        => DateTime.TryParseExact(input, dateFormat, CultureInfo.InvariantCulture,
            DateTimeStyles.AssumeUniversal, out var date)
            && DateTime.Compare(DateTime.UtcNow, date) >= 0;

    /// <summary>
    /// Validates if the input is a valid date in the specified format within the specified date range.
    /// </summary>
    /// <param name="input">The input string to validate.</param>
    /// <param name="dateFormat">The date format to validate the input against.</param>
    /// <param name="validStartDate">The start date of the valid range.</param>
    /// <param name="validEndDate">The end date of the valid range.</param>
    /// <returns>True if the input is a valid date within the specified date range; otherwise, false.</returns>
    public static bool IsValidDate(string? input, string dateFormat,
        DateTime validStartDate, DateTime validEndDate)
        => DateTime.TryParseExact(input, dateFormat, CultureInfo.InvariantCulture,
               DateTimeStyles.AssumeUniversal, out DateTime date)
            && DateTime.Compare(validStartDate, date) <= 0
            && DateTime.Compare(validEndDate, date) >= 0;

    /// <summary>
    /// Validates if the input is a valid choice from the list of choices.
    /// </summary>
    /// <param name="input">The input string to validate.</param>
    /// <param name="choices">The list of valid choices.</param>
    /// <returns>True if the input is a valid choice; otherwise, false.</returns>
    public static bool IsValidChoice(string? input, List<string> choices)
        => !string.IsNullOrEmpty(input) && choices.Contains(input);
}