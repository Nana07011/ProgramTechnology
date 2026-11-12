namespace GuessGameProgram.BaseOfTheGame;
// Реализация основной логики игры, подсказки больше/меньше и правильное число
public class GameHintLogic : IGameHintLogic
{
    public GuessResultHint GetHint(int secret, int guess)
    {
        if (guess == secret) return GuessResultHint.Correct;
        return guess < secret ? GuessResultHint.Greater : GuessResultHint.Less;
    }
}
