namespace GuessGameProgram.UserInteraction;
// SRP. Выполняет только работу с консолью
public class ConsoleInput : IInput
{
    public string ReadLine()
    {
        return Console.ReadLine();
    }
}
