namespace GuessNumberGame.GameLogic;
// Реализация правил игры (Отвечает только за правила самой игры)
public class GuessNumberGameLogic : IGameLogic
{
    public int MinNumber => 1;
    public int MaxNumber => 100;
    public GuessResult Compare(int hiddenNumber, int guess)
    {
        if (guess < hiddenNumber) return GuessResult.TooLow;
        if (guess > hiddenNumber) return GuessResult.TooHigh;
        return GuessResult.Correct;
    }
    public bool IsValidGuess(string input, out int value)
    {
        return int.TryParse(input, out value) && value >= MinNumber && value <= MaxNumber;
    }
}
