using GuessGameProgram.BaseOfTheGame;
using GuessGameProgram.UserInteraction;

namespace GuessGameProgram.Events;

public class ViewEvents
{
    private readonly IOutput _output;

    public ViewEvents(IOutput output, GameEvents gameEvents)
    {
        _output = output;

        gameEvents.GuessMade += OnGuessMade;
        gameEvents.GameFinish += OnGameFinish;
    }

    private void OnGameFinish(object? sender, GameFinishEvents e)
    {
        if (e.IsWin)
        {
            _output.WriteLine($"Вы угадали число {e.SecretNumber} ! За {e.AttemptsUsed} попыток.");
        }
        else
        {
            _output.WriteLine($"Вы проиграли. Загаданное число: {e.SecretNumber}");
        }
    }

    private void OnGuessMade(object? sender, UserGameEvents e)
    {
        string hintText = e.Hint == GuessResultHint.Greater? "Число больше" : "Число меньше";
        _output.WriteLine($"Подсказка : { hintText }. Осталось попыток: {e.AttemptsLeft}");
    }
}
