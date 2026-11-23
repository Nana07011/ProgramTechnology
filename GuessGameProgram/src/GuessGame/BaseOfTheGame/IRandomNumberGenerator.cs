namespace GuessGameProgram.BaseOfTheGame;
// DIP и SRP. Позволяет подменить генератор.
// Можно использовать для тестов, написать класс,
// возвращающий конкретное число для примера
public interface IRandomNumberGenerator
{
    int Next(int minNumber, int maxNumber);
}
