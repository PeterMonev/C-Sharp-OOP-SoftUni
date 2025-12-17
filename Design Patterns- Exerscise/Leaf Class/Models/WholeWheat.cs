using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leaf_Class.Models
{
    public class WholeWheat : Bread
    {
        public override void Bake()
        {
            Console.WriteLine("Gathering ingredients for Whole Wheat Bread.");
        }

        public override void MixIngredients()
        {
            Console.WriteLine("Mixing ingredients for Whole Wheat Bread. (15 minutes).");
        }
    }
}
