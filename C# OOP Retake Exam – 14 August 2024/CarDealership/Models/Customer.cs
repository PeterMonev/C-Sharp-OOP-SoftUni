using CarDealership.Models.Contracts;
using CarDealership.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Models
{
    public abstract class Customer : ICustomer
    {
        private string name;
        private List<string> vehiclesPurchased;

        protected Customer(string name)
        {
            this.Name = name;
            this.vehiclesPurchased = new List<string>();
        }

        public string Name
        {
            get { return this.name; }
            private set
            {

                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.NameIsRequired);
                }

                this.name = value;
            }
        }

        public IReadOnlyCollection<string> Purchases => vehiclesPurchased.AsReadOnly();

        public void BuyVehicle(string vehicleModel)
        {
            vehiclesPurchased.Add(vehicleModel);
        }

        public override string ToString()
        {
            return $"{this.Name} - Purchases: {vehiclesPurchased.Count}";
        }
    }
}
