namespace GuessGameProgram.Difficulty;
// OCP. Движок не знает о сложности, просто передает переменные из интерфейса.
public interface IDifficultyLevel
{
    string Level { get; }
    int MinNumber { get; }
    int MaxNumber { get; }
    int MaxAttempts { get; }
}
