namespace GuessGameProgram.UserInteraction;

public class ConsoleInput : IInput
{
    public string ReadLine()
    {
        return Console.ReadLine() ?? string.Empty;
    }
}
