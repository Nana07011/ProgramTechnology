namespace GuessGameProgram.BaseOfTheGame;
// Интерфейс для генерации случайного числа между мин и макс значением
public interface IRandomNumberGenerator
{
    int Next(int minNumber, int maxNumber);
}
