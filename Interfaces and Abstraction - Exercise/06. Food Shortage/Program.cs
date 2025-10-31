using FoodShortage.Models;
using FoodShortage.Models.Interfaces;

namespace FoodShortage
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<string, IBuyer> buyers = new Dictionary<string, IBuyer>();

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(" ");

                if (input.Length == 4)
                {
                    buyers[input[0]] = new Citizen(input[0], input[1], input[2], input[3]);
                }
                else if (input.Length == 3)
                {

                    buyers[input[0]] = new Rebel(input[0], input[1], input[2]);
                }
            }

            string command;

            while ((command = Console.ReadLine()) != "End")
            {
                if (buyers.ContainsKey(command))
                {
                    buyers[command].BuyFood();
                }
            }

            Console.WriteLine(buyers.Values.Sum(x => x.Food));
        }
    }
}

