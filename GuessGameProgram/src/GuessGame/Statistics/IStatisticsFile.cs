namespace GuessGameProgram.Statistics;
// ISP и DIP. Методы интерфейса логически связаны
// Program и StatisticsView зависит от этого интерфейса
// , а не от класса файла 
public interface IStatisticsFile
{
    void SaveResultsOnFile(GameResult result);
    List<GameResult> GetResults();
}
