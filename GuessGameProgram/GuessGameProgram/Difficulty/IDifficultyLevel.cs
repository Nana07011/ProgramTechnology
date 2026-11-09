namespace GuessGameProgram.Difficulty;

public interface IDifficultyLevel
{
    string Level { get; }
    int MinNumber { get; }
    int MaxNumber { get; }
    int MaxAttempts { get;}
}
