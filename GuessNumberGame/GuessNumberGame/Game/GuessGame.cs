
namespace GuessNumberGame.Game;
// Реализация игровой партии (Отвечает за запуск игры)
public class GuessGame : IGame
{
    private readonly IGameSession _session;

    public GuessGame(IGameSession session)
    {
        _session = session;
    }

    public void Run() => _session.Start();
}