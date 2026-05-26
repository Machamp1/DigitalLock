namespace TheOnlyRightProject;

public interface ILogger
{
    public void WriteInformation(string message);
    public void WriteInputMistake(string message);
    public void WriteRightAnswer(string message);
    public void WriteWrongAnswer(string message);
    public void WriteStartingMessage(string message);
}