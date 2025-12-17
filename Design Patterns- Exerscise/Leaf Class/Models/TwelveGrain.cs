using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leaf_Class.Models
{
    public class TwelveGrain : Bread
    {
        public override void Bake()
        {
            Console.WriteLine("Gathering ingredients for 12-Grain Bread.");
        }

        public override void MixIngredients()
        {
            Console.WriteLine("Mixing ingredients for 12-Grain Bread. (25 minutes).");
        }
    }
}
