using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarDealership.Models.Contracts;

namespace CarDealership.Models
{
    public class SUV : Vehicle
    {
        private const double PriceIncreaseFactor = 1.20;
        public SUV(string model, double price) : base(model, price * PriceIncreaseFactor)
        {
        }
    }
}
