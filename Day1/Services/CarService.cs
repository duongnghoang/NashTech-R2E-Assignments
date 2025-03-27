using Day1.Entities;
using Day1.Utils;

namespace Day1.Services
{
    internal class CarService
    {
        private readonly List<Car> _cars =
        [
            new Car("Tesla", "Model S", 2021, CarType.Electric),
            new Car("Ford", "F-150", 2021, CarType.Fuel),
            new Car("Chevrolet", "Bolt", 2021, CarType.Electric)
        ];

        public void ViewAllCars()
        {
            foreach (var car in _cars)
            {
                Console.WriteLine(car);
            }
        }

        public void AddNewCar()
        {
            CarType carType = InputUtils.GetUserEnumInput<CarType>(
                "Enter car type (Fuel/Electric):", 
                "Invalid car type! Try again:"
                );

            string? make = InputUtils.GetUserStringInput(
                "Enter Make:", 
                "Invalid make! Try again:"
                );

            string? model = InputUtils.GetUserStringInput(
                "Enter Model:", 
                "Invalid model! Try again:"
                );

            int year = InputUtils.GetUserYearInput(
                "Enter Year:", 
                "Invalid year! Try again:"
                );

            Car car = new Car
            {
                Make = make,
                Model = model,
                Year = year,
                Type = carType
            };
            _cars.Add(car);
            Console.WriteLine("Car added successfully!");
        }

        public void SearchCarByMake()
        {
            string? make = InputUtils.GetUserStringInput(
                "Enter Make:",
                "Input cannot be empty! Try again:"
                );
            Car? car =  _cars.FirstOrDefault(car => car.Make!.Equals(make, StringComparison.OrdinalIgnoreCase)) ?? null;
            if (car != null)
            {
                Console.WriteLine(car);
            }
            else
            {
                Console.WriteLine("Car not found");
            }
        }

        public void FilterCarByType()
        {

            CarType carType = InputUtils.GetUserEnumInput<CarType>(
                "Enter car type (Fuel/Electric):",
                "Invalid car type! Try again:"
            );
            List<Car> search = _cars.Where(car => car.Type.Equals(carType)).ToList();
            if (search.Count == 0)
            {
                Console.WriteLine("No cars found");
                return;
            }
            foreach (var car in search)
            {
                Console.WriteLine(car);
            }
        } 

        public void RemoveCarByModel()
        {
            string model = InputUtils.GetUserStringInput(
                "Enter Model:",
                "Input cannot be empty! Try again:"
                );
            int numberOfCarsRemoved = _cars.RemoveAll(car => car.Model == model);
            Console.WriteLine($"{numberOfCarsRemoved} car(s) removed");
        }
    }
}
