namespace Collector
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var spy = new Spy();

            var result = spy.CollectGettersAndSetters("Collector.Hacker");

            Console.WriteLine(result);
        }
    }
}
