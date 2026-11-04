namespace GuessNumberGame.RandomGeneration;
// Генерация случайных чисел в диапазоне от мин и макс значений
public interface IRandomNumberGenerator
{
    int Generate(int min, int max);
}
