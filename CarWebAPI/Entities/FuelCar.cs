using CarWebAPI.Interfaces;

namespace CarWebAPI.Entities;

public class FuelCar : Car, IFuelable
{
    public FuelCar(string make, string model, int year, DateTime lastMaintenanceDate) 
        : base(make, model, year, lastMaintenanceDate)
    {
    }

    public override DateTime ScheduleMaintenance()
    {
        return LastMaintenanceDate.AddMonths(12);
    }

    public void Refuel(DateTime timeOfRefuel)
    {
        Console.WriteLine($"{GetType().Name} {Make} {Model} refueled on {timeOfRefuel:yyyy-MM-dd HH:mm}"); 
    }
}