using Day2.Interfaces;

namespace Day2.Entities;

public class ElectricCar : Car, IChargeable
{
    public ElectricCar(string make, string model, int year, DateTime lastMaintenanceDate) 
        : base(make, model, year, lastMaintenanceDate)
    {
    }

    public void Charge(DateTime timeOfCharge)
    {
        Console.WriteLine($"{GetType().Name} {Make} {Model} recharged on {timeOfCharge:yyyy-MM-dd HH:mm}");
    }
}