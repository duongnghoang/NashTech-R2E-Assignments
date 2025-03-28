using Day2.Constants;
using Day2.Entities;
using Day2.Interfaces;
using Day2.Utils;

namespace Day2.Services;

/// <summary>
///     Service class to handle operations related to Car entities.
/// </summary>
internal class CarService
{
    private readonly List<string> _carTypeChoices = new() { "F", "E" };
    private readonly List<string> _refuelChargeChoices = new() { "Y", "N" };

    /// <summary>
    ///     Prompts the user to input car details and creates a Car object based on the input.
    /// </summary>
    /// <returns>A Car object (either FuelCar or ElectricCar) based on user input.</returns>
    public Car GetUserCar()
    {
        // Get car make from user input
        var make = InputUtils.GetUserStringInput(
            ApplicationMessage.InputCarMake,
            ApplicationMessage.InvalidCarMake
        );

        // Get car model from user input
        var model = InputUtils.GetUserStringInput(
            ApplicationMessage.InputCarModel,
            ApplicationMessage.InvalidCarModel
        );

        // Get car year from user input
        var year = InputUtils.GetUserYearInput(
            ApplicationMessage.InputYear,
            ApplicationMessage.InvalidYear
        );

        // Get last maintenance date from user input
        var lastMaintenanceDate = InputUtils.GetUserMaintenanceDateInput(
            ApplicationMessage.InputMaintenanceDate(DateFormat.IsoDate),
            DateFormat.IsoDate,
            year
        );

        // Get car type from user input
        var carType = InputUtils.GetUserChoice(
            ApplicationMessage.InputCarType,
            ApplicationMessage.InvalidCarType,
            _carTypeChoices
        );

        // Create and return the appropriate Car object based on car type
        if (carType == "E") return new ElectricCar(make, model, year, lastMaintenanceDate);
        return new FuelCar(make, model, year, lastMaintenanceDate);
    }

    /// <summary>
    ///     Displays the details of the specified car.
    /// </summary>
    /// <param name="car">The car whose details are to be displayed.</param>
    public void ShowCarDetails(Car car) => car.DisplayDetails();

    /// <summary>
    ///     Prompts the user to decide whether to refuel or charge the car, and performs the action if confirmed.
    /// </summary>
    /// <param name="car">The car to be refueled or charged.</param>
    public void RefuelOrChargeCar(Car car)
    {
        // Get user choice for refuel or charge
        var isRefuelCharge = InputUtils.GetUserChoice(
            ApplicationMessage.InputRefuelCharge,
            ApplicationMessage.InvalidRefuelCharge,
            _refuelChargeChoices
        );

        // If user chooses to refuel or charge
        if (isRefuelCharge == "Y")
        {
            // Get the date and time of refuel or charge
            var timeOfRefuel = InputUtils.GetUserDateTimeInput(
                ApplicationMessage.InputRefuelChargeDateTime,
                ApplicationMessage.InvalidRefuelChargeDate(car.LastMaintenanceDate, DateTime.Now),
                DateFormat.IsoDateTimeNoSeconds,
                car.LastMaintenanceDate,
                DateTime.Now
            );
            // Perform the relevant action based on car type
            switch (car)
            {
                case IChargeable electricCar:
                {
                    electricCar.Charge(timeOfRefuel);
                    break;
                }
                case IFuelable fuelCar:
                {
                    fuelCar.Refuel(timeOfRefuel);
                    break;
                }
            }
        }
    }
}