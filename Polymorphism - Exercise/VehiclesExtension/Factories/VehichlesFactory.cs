using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vehicles.Factories.Interfaces;
using Vehicles.Models;
using Vehicles.Models.Interfaces;

namespace Vehicles.Factories
{
    public class VehichlesFactory : IVehiclesFactory
    {
        public Models.Interfaces.Vehicle Create(string type, double fuelQuantity, double fuelConsumption, double tankCapacitys)
        {
            switch (type)
            {
                case "Car":
                    return new Car(fuelQuantity, fuelConsumption, tankCapacitys);
                case "Truck":
                    return new Truck(fuelQuantity, fuelConsumption, tankCapacitys);
                case "Bus":
                    return new Bus(fuelQuantity, fuelConsumption, tankCapacitys);
                default:
                        throw new ArgumentException($"Invalid vehicle type: {type}");

            }

        }
    }
}
