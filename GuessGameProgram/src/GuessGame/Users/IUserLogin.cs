namespace GuessGame.Users;

public interface IUserLogin
{
    User? Login(string username, string password);
    User? Register(string  username, string password);
}
