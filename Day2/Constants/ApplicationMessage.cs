namespace Day2.Constants;

public class ApplicationMessage
{
    //Input Messages
    public const string InputCarMake = "Enter car make: ";
    public const string InputCarModel = "Enter car model: ";
    public const string InputYear = "Enter car year (e.g., 2020): ";
    public const string InputCarType = "Is this a FuelCar or ElectricCar? (F/E): ";
    public static string InputMaintenanceDate(string dateFormat) => $"Enter last maintenance date ({dateFormat}): ";
    public const string InputRefuelCharge = "Do you want to refuel/charge? (Y/N): ";
    public const string InputRefuelChargeDateTime = "Enter refuel/charge date and time (yyyy-MM-dd HH:mm): ";

    //Invalid Messages
    public const string InvalidCarMake = "Invalid car make! Please enter a valid car make.";
    public const string InvalidCarModel = "Invalid car model! Please enter a valid car model.";
    public const string InvalidYear = "Invalid year! Please enter a valid year between 1886 and the current year.";
    public const string InvalidCarType = "Invalid input! Please enter 'F' for FuelCar and 'E' for ElectricCar";
    public const string InvalidRefuelCharge = "Invalid choice! Please enter 'Y' for Yes and 'N' for No.";
    public static string InvalidMaintenanceDate(DateTime validStartDate, DateTime validEndDate) =>
        $"Invalid maintenance date! Please enter a valid date between {validStartDate:yyyy-MM-dd} and {validEndDate:yyyy-MM-dd}.";
    public static string InvalidDateMessage(string dateFormat) => $"Invalid date format! Please enter a valid date {dateFormat}.";
}