namespace TheOnlyRightProject;

public class ConsoleLogger: ILogger
{
    public void WriteInformation(string message)
    {
        System.Console.WriteLine(message);
    }
}