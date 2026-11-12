namespace GuessGameProgram.Difficulty;

public class HardLevel : IDifficultyLevel
{
    public string Level => "Сложный";

    public int MinNumber => 1;

    public int MaxNumber => 100;

    public int MaxAttempts => 5;
} 
