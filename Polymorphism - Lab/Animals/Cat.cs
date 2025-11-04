using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animals
{
    public class Cat : Animal
    {
        public Cat(string name, string favouriteFood)
            :base(name, favouriteFood)
        {

        }
        public string Name { get; private set; }

        public string FavouriteFood { get; private set; }
        public override string ExplainSelf()
        {
            return base.ExplainSelf() + Environment.NewLine + "MEEOW";
        }
    }
}
