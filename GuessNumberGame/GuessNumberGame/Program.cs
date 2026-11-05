using GuessNumberGame.Game;
using GuessNumberGame.GameLogic;
using GuessNumberGame.RandomGeneration;
using GuessNumberGame.Statistics;
using GuessNumberGame.UserInteraction;

var console = new ConsoleUser();
var logic = new GuessNumberGameLogic();
var statistics = new StatisticsCollector();

// раунд
var round = new GameRound(
    new RandomNumberGenerator(),
    console,
    console,
    logic,
    statistics);

// партия
var session = new GameSession(
    round,
    console,
    console,
    statistics);

// запуск игры
IGame game = new GuessGame(session);
game.Run();