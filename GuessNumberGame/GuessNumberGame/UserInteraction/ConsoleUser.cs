namespace GuessNumberGame.UserInteraction;
// Класс работы с консолью
public class ConsoleUser : IUserInput, IUserOutput
{
    public string ReadLine()
    {
        return Console.ReadLine() ?? string.Empty;
    }

    public void WriteLine(string message)
    {
        Console.WriteLine(message);
    }
}
