namespace GuessGameProgram.Difficulty;

public class EasyLevel : IDifficultyLevel
{
    public string Level => "Лёгкий";

    public int MinNumber => 1;

    public int MaxNumber => 25;

    public int MaxAttempts => 10;
}
