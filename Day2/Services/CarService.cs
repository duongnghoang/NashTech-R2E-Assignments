using Day2.Constants;
using Day2.Entities;
using Day2.Interfaces;
using Day2.Utils;

namespace Day2.Services
{
    internal class CarService
    {
        private readonly List<string> _carTypeChoices = ["F", "E"];
        private readonly List<string> _refuelChargeChoices = ["Y", "N"];
        public Car GetUserCar()
        {
            string make = InputUtils.GetUserStringInput(
                ApplicationMessage.InputCarMake,
                ApplicationMessage.InvalidCarMake
            );

            string model = InputUtils.GetUserStringInput(
                ApplicationMessage.InputCarModel,
                ApplicationMessage.InvalidCarModel
            );

            int year = InputUtils.GetUserYearInput(
                ApplicationMessage.InputYear,
                ApplicationMessage.InvalidYear
            );

            DateTime lastMaintenanceDate = InputUtils.GetUserDateTimeInput(
                ApplicationMessage.InputMaintenanceDate(DateFormat.IsoDate),
                DateFormat.IsoDate,
                new DateTime(year, 1, 1),
                DateTime.UtcNow
            );

            var carType = InputUtils.GetUserChoice(
                ApplicationMessage.InputCarType, 
                ApplicationMessage.InvalidCarType,
                _carTypeChoices);

            if (carType == "E")
            {
                return new ElectricCar(make, model, year, lastMaintenanceDate);
            }
            return new FuelCar(make, model, year, lastMaintenanceDate);
        }

        public void RefuelOrChargeCar(Car car)
        {
            var isRefuelCharge = InputUtils.GetUserChoice(
                ApplicationMessage.InputRefuelCharge,
                ApplicationMessage.InvalidRefuelCharge,
                _refuelChargeChoices);

            if (isRefuelCharge == "Y")
            {
                DateTime timeOfRefuel = InputUtils.GetUserDateTimeInput(
                    ApplicationMessage.InputRefuelChargeDateTime,
                    DateFormat.IsoDate
                );
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
}
