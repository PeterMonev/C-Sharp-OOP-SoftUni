using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vehicles.Models.Interfaces;

namespace Vehicles.Models
{
    public abstract class Vehicle : IVehicle
    {
        private double fuelQuantity;
        private double fuelConsumption;

        protected Vehicle(double fuelQuantity, double fuelConsumption)
        {
            FuelQuantity = fuelQuantity;
            FuelConsumption = fuelConsumption;
        }

        public virtual double FuelQuantity { get; private set; }

        public virtual double FuelConsumption { get; private set; }

        public string Drive(double distance)
        {
            if (FuelQuantity < FuelConsumption * distance)
            {
                return $"{GetType().Name} needs refueling";
            }

            FuelQuantity -= distance * FuelConsumption;

            return $"{GetType().Name} travelled {distance} km";
        }

        public virtual void Refuel(double fuel)
        {
            this.FuelQuantity += fuel;
        }

        public override string ToString()
        {
            return $"{GetType().Name}: {FuelQuantity:f2}";
        }
    }
}
