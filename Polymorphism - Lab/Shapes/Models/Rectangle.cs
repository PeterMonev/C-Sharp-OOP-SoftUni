using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes.Models
{
    public class Rectangle : Shapes
    {
        private double height;
        private double width;

        public Rectangle(double height, double width)
        {
            Height = height;
            Width = width;
        }

        public double Height { get { return height; } private set { height = value; } }

        public double Width { get { return width; } private set { width = value; } }

        public override double CalculateArea()
        {
          return this.Width * this.Height;
        }

        public override double CalculatePerimeter()
        {
            return (this.Width + this.Height) * 2;
        }

        public override string Draw()
        {
            return $"Drawing Rectangle";
        }
    }
}
