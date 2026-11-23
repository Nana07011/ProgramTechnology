using GuessGameProgram.BaseOfTheGame;

namespace GuessGameProgram.Events;
// OCP. Протектед и Публичные методы, можно переопределить и безопасно вызвать.
public class GameEvents
{
    public event EventHandler<UserGameEvents>? GuessMade;
    public event EventHandler<GameFinishEvents>? GameFinish;

    protected virtual void OnGuessMade(int guess, GuessResultHint hint, int attemptsLeft)
    {
        GuessMade?.Invoke(this, new UserGameEvents(guess, hint, attemptsLeft));
    }

    protected virtual void OnGameFinish(int secretNumber, int attemptsUsed, bool isWin)
    {
        GameFinish?.Invoke(this, new GameFinishEvents(secretNumber, attemptsUsed, isWin));
    }
    public void RaiseGuessMade(int guess, GuessResultHint hint, int attemptsLeft)
       => OnGuessMade(guess, hint, attemptsLeft);

    public void RaiseGameFinish(int secretNumber, int attemptsUsed, bool isWin)
        => OnGameFinish(secretNumber, attemptsUsed, isWin);
}
