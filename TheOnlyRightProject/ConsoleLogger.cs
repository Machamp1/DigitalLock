namespace TheOnlyRightProject;
/// <summary>
/// class for writing messages with colours
/// </summary>
public class ConsoleLogger: ILogger
{
    //each one of these is for different type of information and each with different colours
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