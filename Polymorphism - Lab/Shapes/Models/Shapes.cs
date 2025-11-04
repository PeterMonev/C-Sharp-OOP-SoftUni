using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes.Models
{
    public abstract class Shapes
    {
        public abstract double CalculatePerimeter();



        public abstract double CalculateArea();
      

        public virtual string Draw()
        {
            return $"Drawing shape";
        }
    }
}
