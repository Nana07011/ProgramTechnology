namespace GuessGameProgram.BaseOfTheGame;
// SRP. Класс отвечает за одну задачу - сравнение чисел. Он не знает откуда они и что с ними будет.
public class GameHintLogic : IGameHintLogic
{
    public GuessResultHint GetHint(int secret, int guess)
    {
        if (guess == secret) return GuessResultHint.Correct;
        return guess < secret ? GuessResultHint.Greater : GuessResultHint.Less;
    }
}
