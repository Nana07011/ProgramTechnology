using GuessGameProgram.BaseOfTheGame;
using GuessGameProgram.Difficulty;
using GuessGameProgram.Events;
using GuessGameProgram.Game;
using GuessGameProgram.Statistics;
using GuessGameProgram.UserInteraction;

namespace GuessGameProgram;
internal class Program
{
    static void Main()
    {
        IOutput output = new ConsoleOutput();
        IInput input = new ConsoleInput();

        IRandomNumberGenerator generator = new RandomNumberGenerator(new Random());
        IGameHintLogic hintLogic = new GameHintLogic();
        IStatisticsFile statisticsFile = new StatisticsFile();
        StatisticsView statisticsVies = new StatisticsView(statisticsFile, output);
        Menu menu = new Menu(output, input);

        GameEvents gameEvents = new GameEvents();
        ViewEvents viewEvents = new ViewEvents(output, gameEvents);

        while (true)
        {
            output.WriteLine("1. Начать новую игру");
            output.WriteLine("2. Посмотреть статистику");
            output.WriteLine("3. Выход");

            string choice = input.ReadLine();

            switch(choice)
            {
                case "1":
                    IDifficultyLevel level = menu.ChooseDifficulty();
                    GuessGameEngine game = new GuessGameEngine(generator, hintLogic, level, input, gameEvents);
                    output.WriteLine($"Загадано число от {level.MinNumber} до {level.MaxNumber}. У вас {level.MaxAttempts} попыток. Попробуйте угадать. ");
                    bool isWin = game.Play();
                    statisticsFile.SaveResultsOnFile(new GameResult(level.Level, isWin, game.AttemptsUsed));
                    output.WriteLine("Нажмите Enter, чтобы вернуться в меню.");
                    input.ReadLine();
                    break;
                case "2":
                    statisticsVies.PrintStatistics();
                    output.WriteLine("Нажмите Enter, чтобы вернуться в меню.");
                    input.ReadLine();
                    break;
                case "3":
                    return;
                default:
                    output.WriteLine("Неверный ввод. Попробуйте снова.");
                    break;
            }
        }
    }
}