using GuessGameProgram.UserInteraction;

namespace GuessGameProgram.Statistics;

public class StatisticsView
{
    private readonly IStatisticsFile _statisticsfile;
    private readonly IOutput _output;

    public StatisticsView(IStatisticsFile statisticsfile, IOutput output)
    {
        _statisticsfile = statisticsfile ?? throw new ArgumentNullException(nameof(statisticsfile));
        _output = output ?? throw new ArgumentNullException(nameof(output));
    }
    public void PrintStatistics()
    {
        var results = _statisticsfile.GetResults();
        if (results.Count == 0)
        {
            _output.WriteLine("Статистика пуста");
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

        _output.WriteLine("Всего игр: " + totalGames);
        _output.WriteLine("Количество побед: " + wins);
        _output.WriteLine("Количество поражений: " + losses);
        _output .WriteLine("Процент побед: " + avgWin.ToString("F1") + "%");
    }
}
