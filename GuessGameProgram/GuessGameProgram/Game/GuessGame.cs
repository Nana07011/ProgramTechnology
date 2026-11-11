using GuessGame.BaseOfGame;
using GuessGameProgram.Difficulty;
using GuessGameProgram.Events;
using GuessGameProgram.UserInteraction;

namespace GuessGameProgram.Game;

public class GuessGame
{
    private readonly IRandomNumberGenerator _randomNumber;
    private readonly IGameHintLogic _hintLogic;
    private readonly IDifficultyLevel _difficulty;
    private readonly IInput _input;
    private readonly GameEvents _gameEvents;

    public GuessGame(IRandomNumberGenerator randomNumber, IGameHintLogic hintLogic, IDifficultyLevel difficulty, IInput input, GameEvents gameEvents)
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
        int attempts = 0;
        bool isWin = false;

        while (attempts < _difficulty.MaxAttempts)
        {
            string input = _input.ReadLine();

            if (!int.TryParse(input, out int guess))
            {
                continue;
            }

            attempts++;
            var hint = _hintLogic.GetHint(hiddenNumber, guess);
            if(hint == GuessResultHint.Correct)
            {
                isWin = true;
                _gameEvents.OnGameFinish(hiddenNumber, attempts, true);
                break;
            }
            else
            {
                _gameEvents.OnGuessMade(guess, hint, _difficulty.MaxAttempts - attempts);
            }
        }
        if (!isWin)
        {
            _gameEvents.OnGameFinish(hiddenNumber, attempts, false);
        }
        return isWin;
    }
}
