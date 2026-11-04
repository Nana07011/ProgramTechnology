using GuessNumberGame.UserInteraction;

namespace GuessNumberGame.Statistics;
// Вывод статистики
public class StatisticsPrinter : IStatisticsPrinter
{
    private readonly IUserOutput _output;

    public StatisticsPrinter(IUserOutput output)
    {
        _output = output;
    }

    public void Print(GameStatistics statistics)
    {
        _output.WriteLine($"min = {statistics.MinAttempts} max = {statistics.MaxAttempts} avg = {statistics.AverageAttempts}");
    }
}