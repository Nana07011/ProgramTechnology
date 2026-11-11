using GuessGame.BaseOfGame;
using GuessGameProgram.Difficulty;
using GuessGameProgram.Events;
using GuessGameProgram.UserInteraction;

namespace GuessGameProgram.Game;

public class GuessGameEngine
{
    private readonly IRandomNumberGenerator _randomNumber;
    private readonly IGameHintLogic _hintLogic;
    private readonly IDifficultyLevel _difficulty;
    private readonly IInput _input;
    private readonly GameEvents _gameEvents;
    public int AttemptsUsed { get; private set; }

    public GuessGameEngine(IRandomNumberGenerator randomNumber, IGameHintLogic hintLogic, IDifficultyLevel difficulty, IInput input, GameEvents gameEvents)
    {
        _randomNumber = randomNumber;
        _hintLogic = hintLogic;
        _difficulty = difficulty;
        _input = input;
        _gameEvents = gameEvents;
    }

    public bool Play()
    {
        int hiddenNumber = _randomNumber.Next(_difficulty.MinNumber, _difficulty.MaxNumber);
        AttemptsUsed = 0;
        bool isWin = false;

        while (AttemptsUsed < _difficulty.MaxAttempts)
        {
            string input = _input.ReadLine();

            if (!int.TryParse(input, out int guess))
            {
                continue;
            }

            AttemptsUsed++;
            var hint = _hintLogic.GetHint(hiddenNumber, guess);
            if(hint == GuessResultHint.Correct)
            {
                isWin = true;
                _gameEvents.OnGameFinish(hiddenNumber, AttemptsUsed, true);
                break;
            }
            else
            {
                _gameEvents.OnGuessMade(guess, hint, _difficulty.MaxAttempts - AttemptsUsed);
            }
        }
        if (!isWin)
        {
            _gameEvents.OnGameFinish(hiddenNumber, AttemptsUsed, false);
        }
        return isWin;
    }
}
