namespace GuessNumberGame.GameLogic;
// Логика игры
public interface IGameLogic
{
    int MinNumber { get; }
    int MaxNumber { get; }
    GuessResult Compare(int hiddenNumber, int guess);
    bool IsValidGuess(string input, out int value);
}
