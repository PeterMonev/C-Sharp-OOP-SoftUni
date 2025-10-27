namespace ShoppingSpree.Models
{
    public class Person
    {
        private string name;
        private decimal money;
        List<Product> products;

        public Person(string name, decimal money)
        {
            Name = name;
            Money = money;
            this.products = new List<Product>();
        }
        public string Name
        {
            get { return name; }
            private set
            {

                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be empty");

                }

                name = value;
            }
        }

        public decimal Money
        {
            get => money;
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Money cannot be negative");
                }
                money = value;
            }
        }

        public IReadOnlyCollection<Product> Products
        {
            get { return products; }
        }

        public void BuyProduct(Product product)
        {
            if (this.Money < product.Cost)
            {
                Console.WriteLine($"{Name} can't afford {product.Name}");
            }
            else
            {
                this.Money -= product.Cost;
                products.Add(product);
                Console.WriteLine($"{Name} bought {product.Name}");

            }
        }
    }
}
