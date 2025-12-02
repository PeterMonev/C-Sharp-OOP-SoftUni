using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarDealership.Models.Contracts;

namespace CarDealership.Models
{
    public class Truck : Vehicle
    {
        private const double PriceIncreaseFactor = 1.30;
        public Truck(string model, double price) : base(model, price * PriceIncreaseFactor)
        {
        }
    }
}
