namespace GuessGameProgram.Difficulty;
// OCP. Если нужно добавить новую сложность, класс не меняется,
// создается новый
public class MediumLevel : IDifficultyLevel
{
    public string Level => "Средний";

    public int MinNumber => 1;

    public int MaxNumber => 50;

    public int MaxAttempts => 7;
}
