namespace GuessGameProgram.Events;
// SRP. Хранит данные для финиша игры для ViewEvents.
public class GameFinishEvents : EventArgs
{
    public int SecretNumber { get; }
    public int AttemptsUsed { get; }
    public bool IsWin { get; }

    public GameFinishEvents(int secretNumber, int attemptsUsed, bool isWin)
    {
        SecretNumber = secretNumber;
        AttemptsUsed = attemptsUsed;
        IsWin = isWin;
    }
}
