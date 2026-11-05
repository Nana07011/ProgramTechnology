namespace GuessNumberGame.Statistics;
// Подсчет для общей статистики (Отвечает только за статистику игры, подсчет)
public class StatisticsCollector : IStatisticsCollector
{
    private int _min = int.MaxValue;
    private int _max;
    private int _total;
    private int _games;
    public void AddGame(int attempts)
    {
        if (attempts < _min) _min = attempts;
        if (attempts > _max) _max = attempts;
        _total += attempts;
        _games++;
    }

    public GameStatistics GetStatistics()
    {
        if (_games == 0)
            return new GameStatistics { MinAttempts = 0, MaxAttempts = 0, AverageAttempts = 0 };

        return new GameStatistics
        {
            MinAttempts = _min,
            MaxAttempts = _max,
            AverageAttempts = (double)_total / _games
        };
    }
}
