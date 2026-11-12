namespace GuessGameProgram.BaseOfTheGame;
// Реализация генерации числа
public class RandomNumberGenerator : IRandomNumberGenerator
{
    private readonly Random _random;
    public RandomNumberGenerator(Random random)
    {
        _random = random ?? throw new ArgumentNullException(nameof(random));
    }
    public int Next(int minNumber, int maxNumber)
    {
        if (minNumber >= maxNumber)
            throw new ArgumentOutOfRangeException(nameof(minNumber), "Минимальное число должно быть меньше положительного");

        return _random.Next(minNumber, maxNumber + 1);
    }
}
