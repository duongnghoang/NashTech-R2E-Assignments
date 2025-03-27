using Day2.Constants;
using Day2.Entities;
using Day2.Services;
using Day2.Utils;

namespace Day2;

public class Program
{
    public static void Main(string[] args)
    {
        CarService carService = new CarService(); 
        var car = carService.GetUserCar();
        carService.RefuelOrChargeCar(car);
    }
}