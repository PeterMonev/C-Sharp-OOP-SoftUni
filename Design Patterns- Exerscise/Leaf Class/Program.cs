using Leaf_Class.Models;

namespace Leaf_Class
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Bread twelveGrain = new TwelveGrain();
            twelveGrain.Make();

            Console.WriteLine(" ");

            Bread sourdDough = new Sourdough();
            sourdDough.Make();

            Console.WriteLine(" ");

            Bread wholeWheat = new WholeWheat();
            wholeWheat.Make();

        }
    }
}
