using GuessGameProgram.BaseOfTheGame;

namespace GuessGameProgram.Events;

public class GameEvents
{
    public event EventHandler<UserGameEvents>? GuessMade;
    public event EventHandler<GameFinishEvents>? GameFinish;

    public void OnGuessMade(int guess, GuessResultHint hint, int attemptsLeft)
    {
        GuessMade?.Invoke(this, new UserGameEvents(guess, hint, attemptsLeft));
    }

    public void OnGameFinish(int secretNumber, int attemptsUsed, bool isWin)
    {
        GameFinish?.Invoke(this, new GameFinishEvents(secretNumber, attemptsUsed, isWin));
    }
}
