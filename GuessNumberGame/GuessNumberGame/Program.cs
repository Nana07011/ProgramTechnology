using GuessNumberGame.Game;
using GuessNumberGame.GameLogic;
using GuessNumberGame.RandomGeneration;
using GuessNumberGame.Round;
using GuessNumberGame.Session;
using GuessNumberGame.Statistics;
using GuessNumberGame.UserInteraction;

internal class Program
{
    public static void Main()
    {
        var console = new ConsoleUser();
        var logic = new GuessNumberGameLogic();
        var random = new RandomNumberGenerator();
        var statistics = new StatisticsCollector();

        var guessReader = new GuessReader(console, console, logic);
        var statisticsPrinter = new StatisticsPrinter(console);

        var round = new GameRound(random, guessReader, console, logic, statistics);

        var session = new GameSession(round, console, console, statistics, statisticsPrinter);

        IGame game = new GuessGame(session);
        game.Run();
    }
}