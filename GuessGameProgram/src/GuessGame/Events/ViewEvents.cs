using GuessGameProgram.BaseOfTheGame;
using GuessGameProgram.UserInteraction;

namespace GuessGameProgram.Events;

public class ViewEvents
{
    private readonly IOutput _output;

    public ViewEvents(IOutput output, GameEvents gameEvents)
    {
        _output = output ?? throw new ArgumentNullException(nameof(output));
        if (gameEvents is null) throw new ArgumentNullException(nameof(gameEvents));

        gameEvents.GuessMade += OnGuessMade;
        gameEvents.GameFinish += OnGameFinish;
    }

    protected virtual void OnGameFinish(object? sender, GameFinishEvents e)
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

    protected virtual void OnGuessMade(object? sender, UserGameEvents e)
    {
        string hintText = e.Hint == GuessResultHint.Greater ? "Число больше" : "Число меньше";
        _output.WriteLine($"Подсказка : {hintText}. Осталось попыток: {e.AttemptsLeft}");
    }
}
