using GuessNumberGame.GameLogic;
using GuessNumberGame.RandomGeneration;
using GuessNumberGame.Statistics;
using GuessNumberGame.UserInteraction;

namespace GuessNumberGame.Game;
// Реализация раунда (Отвечает за один раунд игры)
public class GameRound : IGameRound
{
    private const int MaxInputAttempts = 3;
    private readonly IRandomNumberGenerator _random;
    private readonly IUserInput _input;
    private readonly IUserOutput _output;
    private readonly IGameLogic _logic;
    private readonly IStatisticsCollector _statistics;
    public GameRound(IRandomNumberGenerator random, IUserInput input, IUserOutput output, IGameLogic logic, IStatisticsCollector statistics)
    {
        _random = random;
        _input = input;
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
            var guess = ReadValidGuess();
            if (guess is null) return;
            switch(_logic.Compare(hidden, guess.Value))
            {
                case GuessResult.TooLow:
                    _output.WriteLine("Your number is less");
                    break;
                case GuessResult.TooHigh:
                    _output.WriteLine("Your number is greater");
                    break;
                case GuessResult.Correct:
                    _output.WriteLine("You win");
                    _statistics.AddGame(attempts);
                    return;
            }
        }
    }
    private int? ReadValidGuess()
    {
        for (var i = 0; i < MaxInputAttempts; i++)
        {
            _output.WriteLine($"Input number from [{_logic.MinNumber},{_logic.MaxNumber}]");

            var input = _input.ReadLine();

            if (_logic.IsValidGuess(input, out var value))
                return value;

            _output.WriteLine("Invalid input. Try again.");
        }
        _output.WriteLine("You are dumb");
        return null;
    }
}
