using GuessGame.BaseOfGame;

namespace GuessGameProgram.Events;

public class UserGameEvents : EventArgs
{
    public int Guess { get; }
    public GuessResultHint Hint { get; }
    public int AttemptsLeft { get; }

    public UserGameEvents(int guess, GuessResultHint hint, int attemptsLeft)
    {
        Guess = guess;
        Hint = hint;
        AttemptsLeft = attemptsLeft;
    }
}
