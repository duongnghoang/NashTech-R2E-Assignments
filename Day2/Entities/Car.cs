namespace Day2.Entities;

public abstract class Car
{
    protected Car(string make, string model, int year, DateTime lastMaintenanceDate)
    {
        Make = make;
        Model = model;
        Year = year;
        LastMaintenanceDate = lastMaintenanceDate;
    }
    public string? Make { get; protected set; }
    public string? Model { get; protected set; }
    public int Year { get; protected set; }
    public DateTime LastMaintenanceDate { get; protected set; }

    public virtual DateTime ScheduleMaintenance()
    {
        return LastMaintenanceDate.AddMonths(6);
    }
    public virtual void DisplayDetails()
    {
        Console.WriteLine($"Car: {Make} {Model} ({Year})");
        Console.WriteLine($"Last Maintenance: {LastMaintenanceDate:yyyy-MM-dd}");
        Console.WriteLine($"Next Maintenance: {ScheduleMaintenance():yyyy-MM-dd}");
    }
}