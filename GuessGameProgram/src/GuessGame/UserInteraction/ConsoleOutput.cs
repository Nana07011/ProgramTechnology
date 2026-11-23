namespace GuessGameProgram.UserInteraction;
// SRP. Выполняет только работу с консолью
public class ConsoleOutput : IOutput
{
    public void WriteLine(string message)
    {
        Console.WriteLine(message);
    }
}
