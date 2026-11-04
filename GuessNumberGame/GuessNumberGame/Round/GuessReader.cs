using GuessNumberGame.GameLogic;
using GuessNumberGame.UserInteraction;

namespace GuessNumberGame.Round;
// 3 попытки ввода числа
public class GuessReader : IGuessReader
{
    private const int MaxInputAttempts = 3;
    private readonly IUserInput _input;
    private readonly IUserOutput _output;
    private readonly IGameLogic _logic;

    public GuessReader(IUserInput input, IUserOutput output, IGameLogic logic)
    {
        _input = input;
        _output = output;
        _logic = logic;
    }

    public int? ReadValidGuess()
    {
        _output.WriteLine($"Input number from [{_logic.MinNumber},{_logic.MaxNumber}]");

        for (var i = 0; i < MaxInputAttempts; i++)
        {
            var input = _input.ReadLine();
            if (_logic.IsValidGuess(input, out var value))
                return value;

            _output.WriteLine($"Input number from [{_logic.MinNumber},{_logic.MaxNumber}]");
        }

        return null;
    }
}