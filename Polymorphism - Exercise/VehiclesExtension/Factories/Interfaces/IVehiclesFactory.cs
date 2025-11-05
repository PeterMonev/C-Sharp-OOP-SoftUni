using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vehicles.Models.Interfaces;

namespace Vehicles.Factories.Interfaces
{
    public interface IVehiclesFactory
    {
        Vehicle Create(string type,double fuelQuantity, double fuelConsumption, double tankCapacity);
    }
}
