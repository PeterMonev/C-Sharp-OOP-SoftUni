using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vehicles.Models.Interfaces;

namespace Vehicles.Models
{
    public abstract class Vehicle : Interfaces.Vehicle
    {
        private double fuelQuantity;
        private double fuelConsumption;
        private double tankCapacity;

        protected Vehicle(double fuelQuantity, double fuelConsumption, double tankCapacity)
        {
            FuelQuantity = fuelQuantity;
            FuelConsumption = fuelConsumption;
            TankCapacity = tankCapacity;
        }

        public virtual double FuelQuantity
        {
            get => fuelQuantity;
            private set
            {
                if (value <= TankCapacity)
                {
                    fuelQuantity = value;
                }
            }
        }

        public virtual double FuelConsumption { get; protected set; }
        public double TankCapacity { get; private set; }

        public string Drive(double distance)
        {
            if (FuelQuantity < FuelConsumption * distance)
            {
                return $"{GetType().Name} needs refueling";
            }

            FuelQuantity -= distance * FuelConsumption;

            return $"{GetType().Name} travelled {distance} km";
        }

        public virtual string  Refuel(double fuel)
        {
            if (fuel <= 0)
            {

                return "Fuel must be a positive number";
            }

          if (fuel + FuelQuantity > TankCapacity)
            {

                return $"Cannot fit {fuel} fuel in the tan";

            }
            FuelQuantity += fuel;

            return "Refueled";
        }

        public override string ToString()
        {
            return $"{GetType().Name}: {FuelQuantity:f2}";
        }
    }
}
