using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vehicles.Models.Interfaces
{
    public interface Vehicle
    {
        double FuelQuantity { get; }
        double FuelConsumption { get; }

        double TankCapacity { get; }

        string Drive(double distance);

        string Refuel(double fuel);
    }
}
