namespace CodeTracker
{
    [Author("Victor")]

    public class Program
    {
        [Author("George")]

        static void Main(string[] args)
        {
            var tracker = new Tracker();

            tracker.PrintMethodsByAuthor();
        }
    }
}
