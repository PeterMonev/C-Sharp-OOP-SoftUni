using Composite.Models;

namespace Composite
{
    internal class Program
    {
        static void Main(string[] args)
        {
            GiftBase phone = new SingleGift("Phone", 256);
            Console.WriteLine(phone.CalculateTotalPrice());


        }
    }
}
