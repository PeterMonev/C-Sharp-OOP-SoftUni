using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animals
{
    public abstract class Animal
    {
        private string name;
        private string favouriteFood;

        public Animal(string name, string favouriteFood)
        {
            Name = name;
            FavouriteFood = favouriteFood;

        }

        public string Name { get { return name; } private set { name = value; } }

        public string FavouriteFood { get { return name; } private set { favouriteFood = value; } } 
        public virtual string ExplainSelf()
        {
           return $"I am {this.Name} and my fovourite food is {this.FavouriteFood}";
        }
    }
}
