using CarDealership.Models;
using CarDealership.Models.Contracts;
using CarDealership.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Repositories
{
    public class VehicleRepository : IRepository<IVehicle>
    {
        private readonly List<IVehicle> vehicles;
        public VehicleRepository()
        {
            this.vehicles = new List<IVehicle>();
        }

        public IReadOnlyCollection<IVehicle> Models => vehicles;

        public void Add(IVehicle model)
        {
           vehicles.Add(model);
        }

        public bool Exists(string text)
        {
            return vehicles.Any(v => v.Model == text);
        }

        public IVehicle Get(string text)
        {
            return vehicles.FirstOrDefault(v => v.Model == text);
        }

        public bool Remove(string text)
        {
            IVehicle vehicle = vehicles.FirstOrDefault(v => v.Model == text);

            if (vehicle != null)
            {
                vehicles.Remove(vehicle);
                return true;
            }

            return false;
        }

    }
}
