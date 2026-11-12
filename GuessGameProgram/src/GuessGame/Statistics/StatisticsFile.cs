namespace GuessGameProgram.Statistics;

public class StatisticsFile : IStatisticsFile
{
    private readonly string _file;

    public StatisticsFile(string file = "statistics.txt")
    {
        _file = file ?? throw new ArgumentNullException(nameof(file));
    }

    public List<GameResult> GetResults()
    {
        List<GameResult> results = new List<GameResult>();

        if (!File.Exists(_file)) return results;

        string[] lines = File.ReadAllLines(_file);

        foreach (string line in lines)
        {
            string[] split = line.Split(';');
            if (split.Length != 3) continue;

            string difficulty = split[0];

            if (!bool.TryParse(split[1], out bool isWin)) continue;
            if (!int.TryParse(split[2], out int attempts)) continue;

            results.Add(new GameResult(difficulty, isWin, attempts));
        }
        return results;
    }

    public void SaveResultsOnFile(GameResult result)
    {
        string line = result.DifficultyLevel + ";" + result.WinOrLose + ";" + result.AttemptsUsed;

        using (StreamWriter writer = new StreamWriter(_file, true))
        {
            writer.WriteLine(line);
        }
    }
}
