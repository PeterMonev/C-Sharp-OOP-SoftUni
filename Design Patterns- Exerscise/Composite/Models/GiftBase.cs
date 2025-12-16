using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Composite.Models
{
    public abstract class GiftBase
    {
        protected GiftBase(string name, decimal price)
        {
            Name = name;
            Price = price;
        }

        public string Name { get; protected set; }

        public decimal Price { get; protected set; }

        public abstract decimal CalculateTotalPrice();
    }
}
