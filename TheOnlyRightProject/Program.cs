namespace TheOnlyRightProject;

class Program
{
    static void Main(string[] args)
    {
        ILogger logger = new ConsoleLogger();
        Game game = new Game(logger);
        game.Start();
    }
}