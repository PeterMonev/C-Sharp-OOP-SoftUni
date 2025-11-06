using System.IO.Compression;

namespace SquareRoot
{
    public class Program
    {
        static void Main(string[] args)
        {

            try
            {
                int n = int.Parse(Console.ReadLine());

                if (n < 0)
                {
                    throw new ArgumentException("Invalid number.");

                }
                int result = (int)Math.Sqrt(n);
                Console.WriteLine(result);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            } finally
            {
                Console.WriteLine("Goodbye.");
            }
        }
    }
}
