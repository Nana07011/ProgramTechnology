using GuessNumberGame.Statistics;
using GuessNumberGame.UserInteraction;

namespace GuessNumberGame.Game;
// Реализация цикла играть еще (Отвечает за партию игры(либо несколько подряд либо 1 раунд)
public class GameSession : IGameSession
{
    private readonly IGameRound _round;
    private readonly IUserInput _input;
    private readonly IUserOutput _output;
    private readonly IStatisticsCollector _statistics;
    public GameSession(IGameRound round, IUserInput input, IUserOutput output, IStatisticsCollector statistics)
    {
        _round = round;
        _input = input;
        _output = output;
        _statistics = statistics;
    }

    public void Start()
    {
        do
        {
            _round.Play();
        }
        while (AskPlayAgaing());

        PrintStatistics();
    }

    private void PrintStatistics()
    {
        var stats = _statistics.GetStatistics();
        _output.WriteLine($"min = {stats.MinAttempts} max = {stats.MaxAttempts} avg = {stats.AverageAttempts}");
    }

    private bool AskPlayAgaing()
    {
        _output.WriteLine("Do you want to play again? (Y/N)");
        var answer = _input.ReadLine().ToUpper();
        return answer == "Y" || answer == "YES";
    }
}
