namespace MissionPrivateImpossible
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var spy = new Spy();

            var result = spy.RevealPrivateMethods("MissionPrivateImpossible.Hacker");

            Console.WriteLine(result);
        }
    }
}
