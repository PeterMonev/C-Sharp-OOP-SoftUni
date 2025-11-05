using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vehicles.Models
{
    public class Truck : Vehicle
    {
        private const double IncreasedConsumption = 1.6;
        private const double DecreaseRefuel = 0.95;
        public Truck(double fuelQuantity, double fuelConsumption, double tankCapacity) : base(fuelQuantity, fuelConsumption, tankCapacity)
        {
        }

        public override double FuelConsumption => base.FuelConsumption + IncreasedConsumption;

        public override string Refuel(double fuel)
        {
            if (fuel <= 0)
            {

                return "Fuel must be a postive number";
            }

            if (fuel + FuelQuantity > TankCapacity)
            {

                return $"Cannot fit {fuel} fuel in the tan";

            }

            return base.Refuel(fuel * DecreaseRefuel);
        }
    }
}
