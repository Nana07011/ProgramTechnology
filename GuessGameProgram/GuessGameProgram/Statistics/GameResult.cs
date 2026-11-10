namespace GuessGameProgram.Statistics;

public class GameResult
{
    public string DifficultyLevel { get; set; } = string.Empty;
    public bool WinOrLose { get; set; }
    public int AttemptsUsed { get; set; }
    public GameResult(string difficultyLevel, bool winOrLose, int attemptsUsed)
    {
        DifficultyLevel = difficultyLevel;
        WinOrLose = winOrLose;
        AttemptsUsed = attemptsUsed;
    }
}
