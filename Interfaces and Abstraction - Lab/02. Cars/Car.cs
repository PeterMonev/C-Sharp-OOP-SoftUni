using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cars
{
    public abstract class Cars : ICar
    {

        public Cars(string model, string color)
        {
            Model = model;
            Color = color;
        }

        public string Model { get; protected set; }

        public string Color { get; protected set; }

        public string Start()
        {
            return "Engine start";
        }

        public string Stop()
        {
            return "Breaaak";
        }

        public override string ToString()
        {
            return $"{Color} {this.GetType().Name} {Model}";
        }
    }
}
