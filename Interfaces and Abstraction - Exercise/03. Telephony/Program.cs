using Telephony.Models;
using Telephony.Models.Interfaces;

namespace Telephony { 
  public class StartUp
    {
        static void Main(string[] args)
        {
            string[] phoneNumbers = Console.ReadLine().Split(" ");
            string[] urls = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            foreach (string phone in phoneNumbers)
            {
                if (phone.Length == 10)
                {
                    try
                    {
                        ICallable smartphone = new Smartphone();
                        Console.WriteLine(smartphone.Call(phone));
                    } catch (ArgumentException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
            
                } else
                {
                    try
                    {
                        ICallable smartphone = new StationaryPhone();
                        Console.WriteLine(smartphone.Call(phone));
                    } catch (ArgumentException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                   
                }
            }

            foreach (string url in urls)
            {

                try
                {
                    IBrowsable smartphone = new Smartphone();
                    Console.WriteLine(smartphone.Browse(url));
                } catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
               

            }
        }
    }
}