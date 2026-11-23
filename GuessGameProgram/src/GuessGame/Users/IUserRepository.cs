namespace GuessGame.Users;

public interface IUserRepository
{
    User? FindUsername(string username);
    void Add(User user);
    List<User> GetAll();
}
