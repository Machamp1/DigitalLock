namespace TheOnlyRightProject;

public class ConsoleLogger: ILogger
{
    public void WriteInformation(string message)
    {
        Console.ForegroundColor = ConsoleColor.DarkBlue;
        System.Console.WriteLine(message);
        Console.ResetColor();
    }

    public void WriteRightAnswer(string message)
    {
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        System.Console.WriteLine(message);
        Console.ResetColor();
    }

    public void WriteWrongAnswer(string message)
    {
        Console.ForegroundColor = ConsoleColor.DarkRed;
        System.Console.WriteLine(message);
        Console.ResetColor();
    }

    public void WriteInputMistake(string message)
    {
        Console.ForegroundColor = ConsoleColor.DarkYellow;
        System.Console.WriteLine(message);
        Console.ResetColor();
    }


    public void WriteStartingMessage(string message)
    {
        Console.ForegroundColor = ConsoleColor.DarkRed;
        System.Console.WriteLine(message);
        Console.ResetColor();
    }
}