using Day2.Services;

namespace Day2;

public class Program
{
    public static void Main(string[] args)
    {
        CarService carService = new CarService(); 
        var car = carService.GetUserCar();
        carService.ShowCarDetails(car);
        carService.RefuelOrChargeCar(car);
    }
}