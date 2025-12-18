namespace Workshop___Snake
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var randomGenerator = new RandomGenerator();
            var consoleRenderer = new ConsoleSnakeRenderer();
            var consoleInput = new ConsoleSnakeGameInput();
            SnakeGameEnigne gameEnigne = new SnakeGameEnigne(consoleRenderer, consoleInput, randomGenerator);

            gameEnigne.Run();
        }
    }
}
