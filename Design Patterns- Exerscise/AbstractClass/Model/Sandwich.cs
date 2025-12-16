using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractClass.Model
{
    public class Sandwich : SandwichPrototype
    {
        private string bread;
        private string meat;
        private string cheese;
        private string veggies;

        public Sandwich(string bread, string meat, string cheese, string veggies)
        {
            this.bread = bread;
            this.meat = meat;
            this.cheese = cheese;
            this.veggies = veggies;
        }

        public override SandwichPrototype Clone()
        {
            Console.WriteLine($"Cloning sadwich with ingrediens, {GetIngredients()}");

            return this.MemberwiseClone() as SandwichPrototype; 
        }

        public string GetIngredients() => $"{bread}, {meat}, {cheese}, {veggies}";
    }
}
