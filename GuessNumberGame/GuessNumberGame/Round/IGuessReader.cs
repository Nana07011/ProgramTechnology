namespace GuessNumberGame.Round;
// Интерфейс для чтения корректного числа
public interface IGuessReader
{
    int? ReadValidGuess();
}