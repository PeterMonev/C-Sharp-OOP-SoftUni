using PizzaCalories.Models;
using System.ComponentModel;

namespace PizzaCalories
{

    public class StartUp
    {
        static void Main(string[] args)
        {
            try
            {
                string[] pizzaTokenes = Console.ReadLine().Split(" ");
                string[] doughTokenes = Console.ReadLine().Split(" ");

                Pizza pizza = new Pizza(pizzaTokenes[1]);
                Dough dough = new Dough(doughTokenes[1], doughTokenes[2], double.Parse(doughTokenes[3]));

                pizza.Dough = dough;

                string toppingsInput;
                while ((toppingsInput = Console.ReadLine()) != "END")
                {

                    string[] toppingTokens = toppingsInput.Split(" ");
                    Topping topping = new Topping(toppingTokens[0], double.Parse(toppingTokens[1]));
                    pizza.AddTopping(topping);

                }
                Console.WriteLine(pizza.ToString());

            }


            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

    }
}

