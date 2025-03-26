using Day1.Services;
using Day1.Utils;

namespace Day1;

public class Program
{
    public static void Main(string[] args)
    {
        CarService carService = new CarService();
        do
        {
            PrintMenu();
            int choice = InputUtils.GetUserIntInput("Enter your choice:", "Invalid input format! Try again:");
            switch (choice)
            {
                case 1: 
                {
                    carService.AddNewCar();
                    break;
                }
                case 2:
                {
                    carService.ViewAllCars();
                    break;
                }
                case 3:
                {
                    carService.SearchCarByMake();
                    break;
                }
                case 4:
                {
                    carService.FilterCarByType();
                    break;
                }
                case 5:
                {
                    carService.RemoveCarByModel();
                    break;
                }
                case 6:
                {
                    Environment.Exit(0);
                    break;
                }
                default:
                {
                    Console.WriteLine("Choice not found.");
                    continue;
                }
            }
        } while (true);
    }

    private static void PrintMenu()
    {
        string menu = "Menu:\n" +
                      "1. Add a car\n" +
                      "2. View all cars\n" +
                      "3. Search car by make\n" +
                      "4. Filter car by types\n" +
                      "5. Remove a car by model\n" +
                      "6. Exit\n";
        Console.WriteLine(menu);
    }
}