namespace GuessNumberGame.UserInteraction;
// Класс работы с консолью (Отвечает за ввод/вывод, можно выводить за консоль(GUI))
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
