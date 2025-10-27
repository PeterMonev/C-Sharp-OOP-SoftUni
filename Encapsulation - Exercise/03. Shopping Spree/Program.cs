using ShoppingSpree.Models;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace ShoppingSpree
{
    public class StartUp
    {
        public static void Main()
        {
            try
            {
                Dictionary<string, Person> people = new Dictionary<string, Person>();
                Dictionary<string, Product> products = new Dictionary<string, Product>();

                string[] firstInput = Console.ReadLine().Split(";", StringSplitOptions.RemoveEmptyEntries);
                foreach (var line in firstInput)
                {
                    string[] parts = line.Split("=");
                    string name = parts[0];
                    decimal money = decimal.Parse(parts[1], CultureInfo.InvariantCulture);
                    people[name] = new Person(name, money);
                }

                string[] secondInput = Console.ReadLine().Split(";", StringSplitOptions.RemoveEmptyEntries);
                foreach (var line in secondInput)
                {
                    string[] parts = line.Split("=");
                    string name = parts[0];
                    decimal cost = decimal.Parse(parts[1], CultureInfo.InvariantCulture);
                    products[name] = new Product(name, cost);
                }

                string command;
                while ((command = Console.ReadLine()) != "END")
                {
                    string[] parts = command.Split(' ');
                    string personName = parts[0];
                    string productName = parts[1];

                    if (people.ContainsKey(personName) && products.ContainsKey(productName))
                    {
                        people[personName].BuyProduct(products[productName]);
                    }
                }

                foreach (var person in people.Values)
                {
                    if (person.Products.Count == 0)
                        Console.WriteLine($"{person.Name} - Nothing bought");
                    else
                        Console.WriteLine($"{person.Name} - {string.Join(", ", person.Products)}");
                }
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
