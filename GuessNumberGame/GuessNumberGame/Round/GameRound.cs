using GuessNumberGame.GameLogic;
using GuessNumberGame.RandomGeneration;
using GuessNumberGame.Statistics;
using GuessNumberGame.UserInteraction;

namespace GuessNumberGame.Round;
// Реализация одного раунда
public class GameRound : IGameRound
{
    private readonly IRandomNumberGenerator _random;
    private readonly IGuessReader _guessreader;
    private readonly IUserOutput _output;
    private readonly IGameLogic _logic;
    private readonly IStatisticsCollector _statistics;

    public GameRound (IRandomNumberGenerator random, IGuessReader guessReader,
        IUserOutput output, IGameLogic logic, IStatisticsCollector statistics)
    {
        _random = random;
        _guessreader = guessReader;
        _output = output;
        _logic = logic;
        _statistics = statistics;
    }

    public void Play()
    {
        var hidden = _random.Generate(_logic.MinNumber, _logic.MaxNumber);
        var attempts = 0;

        while (true)
        {
            attempts++;
            var guess = _guessreader.ReadValidGuess();

            if (guess is null)
            {
                _output.WriteLine("You are dumb");
                return;
            }

            switch (_logic.Compare(hidden, guess.Value))
            {
                case GuessResult.TooLow: _output.WriteLine("Your number is less");
                    break;
                case GuessResult.TooHigh: _output.WriteLine("Your number is greater");
                    break;
                case GuessResult.Correct:
                    _output.WriteLine("You win!");
                    _statistics.AddGame(attempts);
                    return;
            }
        }
    }
}
