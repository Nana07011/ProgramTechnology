using GuessGameProgram.BaseOfTheGame;
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
    private readonly IOutput _output;
    public int AttemptsUsed { get; private set; }

    public GuessGameEngine(IRandomNumberGenerator randomNumber, IGameHintLogic hintLogic, IDifficultyLevel difficulty, IInput input, GameEvents gameEvents, IOutput output)
    {
        _randomNumber = randomNumber;
        _hintLogic = hintLogic;
        _difficulty = difficulty;
        _input = input;
        _gameEvents = gameEvents;
        _output = output;
    }

    public bool Play()
    {
        int hiddenNumber = _randomNumber.Next(_difficulty.MinNumber, _difficulty.MaxNumber);
        AttemptsUsed = 0;
        bool isWin = false;

        while (AttemptsUsed < _difficulty.MaxAttempts)
        {
            int guess = 0;
            bool isValid = false;

            for (int i = 0; i < 3; i++)
            {
                string input = _input.ReadLine();

                if (int.TryParse(input, out guess))
                {
                    if (guess < _difficulty.MinNumber || guess > _difficulty.MaxNumber){
                        _output.WriteLine($"Введите число от {_difficulty.MinNumber} до {_difficulty.MaxNumber}.");
                    }
                    isValid = true;
                    break;
                }
            }

            if (!isValid)
            {
                _gameEvents.RaiseGameFinish(hiddenNumber, AttemptsUsed, false);
                return false;
            }

            AttemptsUsed++;
            var hint = _hintLogic.GetHint(hiddenNumber, guess);
            if(hint == GuessResultHint.Correct)
            {
                isWin = true;
                _gameEvents.RaiseGameFinish(hiddenNumber, AttemptsUsed, true);
                break;
            }
            else
            {
                _gameEvents.RaiseGuessMade(guess, hint, _difficulty.MaxAttempts - AttemptsUsed);
            }
        }
        if (!isWin)
        {
            _gameEvents.RaiseGameFinish(hiddenNumber, AttemptsUsed, false);
        }
        return isWin;
    }
}
