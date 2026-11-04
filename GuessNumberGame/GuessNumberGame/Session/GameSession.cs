using GuessNumberGame.Round;
using GuessNumberGame.Statistics;
using GuessNumberGame.UserInteraction;

namespace GuessNumberGame.Session;
// Реализация сессии игры
public class GameSession : IGameSession
{
    private readonly IGameRound _round;
    private readonly IUserInput _input;
    private readonly IUserOutput _output;
    private readonly IStatisticsCollector _statistics;
    private readonly IStatisticsPrinter _statisticsPrinter;

    public GameSession(
        IGameRound round, IUserInput input, IUserOutput output,
        IStatisticsCollector statistics, IStatisticsPrinter statisticsPrinter)
    {
        _round = round;
        _input = input;
        _output = output;
        _statistics = statistics;
        _statisticsPrinter = statisticsPrinter;
    }

    public void Start()
    {
        do
        {
            _round.Play();
        }
        while (AskPlayAgain());

        _statisticsPrinter.Print(_statistics.GetStatistics());
    }
    private bool AskPlayAgain()
    {
        _output.WriteLine("Do you want to play again? (Y/N)");
        var answer = _input.ReadLine().ToUpper();

        return answer == "Y" || answer == "YES";
    }
}
