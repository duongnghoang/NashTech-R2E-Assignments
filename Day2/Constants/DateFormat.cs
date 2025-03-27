namespace Day2.Constants;

public class DateFormat
{
    // ISO Date Formats
    public const string IsoDate = "yyyy-MM-dd"; // Example: 2025-03-27
    public const string IsoDateTime = "yyyy-MM-dd HH:mm:ss"; // Example: 2025-03-27 09:26:08
    public const string IsoDateTimeNoSeconds = "yyyy-MM-dd HH:mm"; // Example: 2025-03-27 09:26:08

    // US Date Formats
    public const string UsDate = "MM/dd/yyyy"; // Example: 03/27/2025
    public const string UsDateTime = "MM/dd/yyyy HH:mm:ss"; // Example: 03/27/2025 09:26:08

    // EU Date Formats
    public const string EuDate = "dd-MM-yyyy"; // Example: 27-03-2025
    public const string EuDateTime = "dd-MM-yyyy HH:mm:ss"; // Example: 27-03-2025 09:26:08

    // Compact Date Formats
    public const string CompactDate = "yyyyMMdd"; // Example: 20250327
    public const string CompactDateTime = "yyyyMMddTHHmmss"; // Example: 20250327T092608

    // Long Date Formats
    public const string LongDate = "dddd, dd MMMM yyyy"; // Example: Thursday, 27 March 2025
    public const string Rfc1123DateTime = "ddd, dd MMM yyyy HH:mm:ss 'GMT'"; // Example: Thu, 27 Mar 2025 09:26:08 GMT

    // Additional EU Date Formats with slashes
    public const string EuDateSlash = "dd/MM/yyyy"; // Example: 27/03/2025
    public const string EuDateTimeSlash24H = "dd/MM/yyyy HH:mm:ss"; // Example: 27/03/2025 09:26:08
    public const string EuDateTimeSlash12H = "dd/MM/yyyy hh:mm tt"; // Example: 27/03/2025 09:26 AM
    public const string EuDateTimeSlashNoSeconds24H = "dd/MM/yyyy HH:mm"; // Example: 27/03/2025 09:26
    public const string EuDateTimeSlashNoSeconds12H = "dd/MM/yyyy hh:mm:ss tt"; // Example: 27/03/2025 09:26:08 AM
}