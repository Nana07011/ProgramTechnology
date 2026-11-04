namespace GuessNumberGame.Statistics;
// Сбор статистики
public interface IStatisticsCollector
{
    void AddGame(int attempts);
    GameStatistics GetStatistics();
}
