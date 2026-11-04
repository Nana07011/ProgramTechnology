using GuessNumberGame.Session;
namespace GuessNumberGame.Game;
// Реализация игровой партии
public class GuessGame : IGame
{
    private readonly IGameSession _session;

    public GuessGame(IGameSession session)
    {
        _session = session;
    }

    public void Run() => _session.Start();
}