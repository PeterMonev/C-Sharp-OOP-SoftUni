using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leaf_Class.Models
{
    internal class Sourdough : Bread
    {
        public override void Bake()
        {
            Console.WriteLine("Gathering ingredients for Sourdough Bread.");
        }

        public override void MixIngredients()
        {
            Console.WriteLine("Mixing ingredients for Sourdough Bread. (15 minutes).");
        }
    }
}
