using CarDealership.Core.Contracts;
using CarDealership.Models;
using CarDealership.Models.Contracts;
using CarDealership.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Core
{
    public class Controller : IController
    {
        private readonly IDealership dealership;

        public Controller()
        {
            this.dealership = new Dealership();
        }
        public string AddCustomer(string customerTypeName, string customerName)
        {
            ICustomer customer;

            if (customerTypeName == nameof(IndividualClient))
            {
                customer = new IndividualClient(customerName);
            }
            else if (customerTypeName == nameof(LegalEntityCustomer))
            {

                customer = new LegalEntityCustomer(customerName);
            }
            else
            {
                return string.Format(OutputMessages.InvalidType, customerTypeName);
            }

            if (dealership.Customers.Exists(customerName))
            {
                return string.Format(OutputMessages.CustomerAlreadyAdded, customerName);
            }

            dealership.Customers.Add(customer);

            return string.Format(OutputMessages.CustomerAddedSuccessfully, customerName);
        }

        public string AddVehicle(string vehicleTypeName, string model, double price)
        {
            IVehicle vehicle;
            if (vehicleTypeName == nameof(SaloonCar))
            {
                vehicle = new SaloonCar(model, price);
            }
            else if (vehicleTypeName == nameof(SUV))
            {
                vehicle = new SUV(model, price);
            }
            else if (vehicleTypeName == nameof(Truck))
            {
                vehicle = new Truck(model, price);
            }
            else
            {
                return string.Format(OutputMessages.InvalidType, vehicleTypeName);
            }

            if (dealership.Vehicles.Models.Any(m => m.Model == model))
            {
                return string.Format(OutputMessages.VehicleAlreadyAdded, model);
            }

            dealership.Vehicles.Add(vehicle);
            return string.Format(OutputMessages.VehicleAddedSuccessfully, vehicleTypeName, model, vehicle.Price.ToString("F2"));

        }

        public string CustomerReport()
        {
            StringBuilder sb = new StringBuilder();

            var customers = dealership.Customers.Models
                .OrderBy(c => c.Name)
                .ToList();

            sb.AppendLine("Customer Report:");

            foreach (var customer in customers)
            {
                sb.AppendLine(customer.ToString());
                sb.AppendLine("-Models:");

                if (!customer.Purchases.Any())
                {
                    sb.AppendLine("--none");
                    continue;
                }

                var purchasedVehicles = customer.Purchases
                    .Select(model => dealership.Vehicles.Models.First(v => v.Model == model))
                    .OrderBy(v => v.Model);

                foreach (var vehicle in purchasedVehicles)
                {
                    sb.AppendLine("--" + vehicle.Model);
                }
            }

            return sb.ToString().TrimEnd();
        }



        public string PurchaseVehicle(string vehicleTypeName, string customerName, double budget)
        {
            if (!dealership.Customers.Exists(customerName))
            {
                return string.Format(OutputMessages.CustomerNotFound, customerName);
            }

            ICustomer customer = dealership.Customers.Get(customerName);

            IVehicle vehicle = dealership.Vehicles.Models
                .FirstOrDefault(v => v.GetType().Name == vehicleTypeName);

            if (vehicle == null)
            {
                return string.Format(OutputMessages.VehicleTypeNotFound, vehicleTypeName);
            }

            if (customer is IndividualClient && !(vehicle is SaloonCar || vehicle is SUV))
            {
                return string.Format(OutputMessages.CustomerNotEligibleToPurchaseVehicle, customerName, vehicleTypeName);
            }
            else if (customer is LegalEntityCustomer && !(vehicle is SUV || vehicle is Truck))
            {
                return string.Format(OutputMessages.CustomerNotEligibleToPurchaseVehicle, customerName, vehicleTypeName);
            }


            List<IVehicle> affordableVehicles = dealership.Vehicles.Models.Where(v => v.GetType().Name == vehicleTypeName && v.Price <= budget).ToList();

            if (!affordableVehicles.Any())
            {
                return string.Format(OutputMessages.BudgetIsNotEnough, customerName, vehicleTypeName);
            }

            IVehicle vehicleToBuy = affordableVehicles.OrderByDescending(v => v.Price).First();

            customer.BuyVehicle(vehicleToBuy.Model);
            vehicleToBuy.SellVehicle(customer.Name);

            return string.Format(OutputMessages.VehiclePurchasedSuccessfully, customerName, vehicleToBuy.Model);

        }

        public string SalesReport(string vehicleTypeName)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{vehicleTypeName} Sales Report:");

            int totalPurchases = 0;

            List<IVehicle> vehicles = dealership.Vehicles.Models
                .Where(v => v.GetType().Name == vehicleTypeName)
                .OrderBy(v => v.Model)
                .ToList();

            foreach (IVehicle vehicle in vehicles)
            {
                sb.AppendLine($"--{vehicle.ToString()}");
                totalPurchases += vehicle.Buyers.Count;
            }

            sb.AppendLine($"-Total Purchases: {totalPurchases}");

            return sb.ToString().TrimEnd();
        }
    }
}
