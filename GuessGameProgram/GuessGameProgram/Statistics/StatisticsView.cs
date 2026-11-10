namespace GuessGameProgram.Statistics;

public class StatisticsView
{
    private readonly IStatisticsFile _statisticsfile;

    public StatisticsView(IStatisticsFile statisticsfile)
    {
        _statisticsfile = statisticsfile ?? throw new ArgumentNullException(nameof(statisticsfile));
    }
    public void PrintStatistics()
    {
        var results = _statisticsfile.GetResults();
        if (results.Count == 0)
        {
            Console.WriteLine("Статистика пуста");
            return;
        }
        int totalGames = results.Count;
        int wins = 0;

        foreach (var result in results)
        {
            if (result.WinOrLose) wins++;
        }

        int losses = totalGames - wins;
        double avgWin = ((double)wins / totalGames) * 100;

        Console.WriteLine("Всего игр: " + totalGames);
        Console.WriteLine("Количество побед: " + wins);
        Console.WriteLine("Количество поражений: " + losses);
        Console.WriteLine("Процент побед: " + avgWin.ToString("F1") + "%");
    }
}
