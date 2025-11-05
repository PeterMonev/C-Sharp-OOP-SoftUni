using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vehicles.Models.Interfaces;

namespace Vehicles.Models
{
    public class Bus : Vehicle, ISpecializedVehicle
    {
        private const double IncreasedConsumption = 1.4;
        public Bus(double fuelQuantity, double fuelConsumption, double tankCapacity)
            : base(fuelQuantity, fuelConsumption, tankCapacity)
        {
        }

        public override double FuelConsumption => base.FuelConsumption + IncreasedConsumption;

        public string DriveEmpty(double distance)
        {
            base.FuelConsumption -= IncreasedConsumption;

            return Drive(distance);
        }
    }
}
