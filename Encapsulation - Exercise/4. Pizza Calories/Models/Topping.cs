using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaCalories.Models
{
    public class Topping
    {
        private const int baseCaloriesPerGram = 2;

        private readonly Dictionary<string, double> toppingCalories;

        private string type;
        private double weigth;


        public Topping(string type, double weigth)
        {
            toppingCalories = new Dictionary<string, double>
            {
                { "meat" , 1.2 },
                { "veggies", 0.8},
                { "cheese", 1.1 },
                { "sauce", 0.9 }
            };

            Type = type;
            Weigth = weigth;

        }

        public string Type
        {
            get { return type; }
            private set { 
              
                if(!toppingCalories.ContainsKey(value.ToLower()))
                {
                    throw new ArgumentException($"Cannot place {value} on top of your pizza.");
                }
                type = value;
            }
        }

        public double Weigth
        {
            get { return weigth; }
            private set { 
                
                if(value < 1 || value > 50)
                {
                    throw new ArgumentException($"{Type} weight should be in the range [1..50].");
                }
                weigth = value; }

        }

        public double Calories
        {
            get
            {
                double toppingTypeModifier = toppingCalories[type.ToLower()];
                return baseCaloriesPerGram * Weigth * toppingTypeModifier;
            }

        }
}
}
