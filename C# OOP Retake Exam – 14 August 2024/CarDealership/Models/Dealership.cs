using CarDealership.Models.Contracts;
using CarDealership.Repositories;
using CarDealership.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Models
{
    public class Dealership : IDealership
    {
        private readonly IRepository<IVehicle> vehicles;
        private readonly IRepository<ICustomer> customers;
        public Dealership()
        {
            this.vehicles = new VehicleRepository();
            this.customers = new CustomerRepository();
        }
        public IRepository<IVehicle> Vehicles => vehicles;

        public IRepository<ICustomer> Customers => customers;
    }
}
