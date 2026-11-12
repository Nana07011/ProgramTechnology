namespace GuessGameProgram.BaseOfTheGame;
// Интерфейс для сравнения числа игрока с загаданным
public interface IGameHintLogic
{
    GuessResultHint GetHint(int secret, int guess);
}
