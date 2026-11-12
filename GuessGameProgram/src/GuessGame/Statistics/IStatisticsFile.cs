namespace GuessGameProgram.Statistics;

public interface IStatisticsFile
{
    void SaveResultsOnFile(GameResult result);
    List<GameResult> GetResults();
}
