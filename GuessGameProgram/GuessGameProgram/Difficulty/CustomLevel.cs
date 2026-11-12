namespace GuessGameProgram.Difficulty;

public class CustomLevel : IDifficultyLevel
{
    public string Level => "Пользовательский";

    public int MinNumber { get; }

    public int MaxNumber { get; }

    public int MaxAttempts {  get; }

    public CustomLevel(int minNumber, int maxNumber, int maxAttempts)
    {
        if (minNumber >= maxNumber)
            throw new ArgumentException("Минимальное число должно быть меньше максимального");
        if(maxAttempts <= 0)
            throw new ArgumentException("Количество попыток должно быть положительным");
        MinNumber = minNumber;
        MaxNumber = maxNumber;
        MaxAttempts = maxAttempts;
    }


}
