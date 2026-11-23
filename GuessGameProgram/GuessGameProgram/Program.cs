using GuessGame.Users;
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
        Menu menu = new Menu(output, input);

        IUserRepository userRepository = new UserRepository();
        IUserLogin userLogin = new UserLogin(userRepository, output);
        UserSessionGame userSession = new UserSessionGame();
        UserLoginMenu loginMenu = new UserLoginMenu(userLogin, output, input);

        User? user = loginMenu.Authorize();

        if (user is null) return;
        userSession.Login(user);
        output.WriteLine("Вы вошли как: " + user.UserName);

        IStatisticsFile statisticsFile = new StatisticsFile("statistics_" + user.Id + ".txt");
        StatisticsView statisticsVies = new StatisticsView(statisticsFile, output);

        GameEvents gameEvents = new GameEvents();
        ViewEvents viewEvents = new ViewEvents(output, gameEvents);

        while (true)
        {
            output.WriteLine("1. Начать новую игру");
            output.WriteLine("2. Посмотреть статистику");
            output.WriteLine("3. Сменить аккаунт");
            output.WriteLine("4. Выход");

            string choice = input.ReadLine();

            switch(choice)
            {
                case "1":
                    IDifficultyLevel level = menu.ChooseDifficulty();
                    GuessGameEngine game = new GuessGameEngine(generator, hintLogic, level, input, gameEvents, output);
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
                    userSession.Logout();
                    output.WriteLine("Вы вышли из аккаунта.");

                    user = loginMenu.Authorize();
                    if (user is null) return;
                    userSession.Login(user);
                    output.WriteLine("Вы вошли как: " + user.UserName);

                    statisticsFile = new StatisticsFile("statistics_" + user.Id + ".txt");
                    statisticsVies = new StatisticsView(statisticsFile, output);
                    break;
                case "4":
                    return;
                default:
                    output.WriteLine("Неверный ввод. Попробуйте снова.");
                    break;
            }
        }
    }
}