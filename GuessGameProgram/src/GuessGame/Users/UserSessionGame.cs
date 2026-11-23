namespace GuessGame.Users;

public class UserSessionGame
{
    public User? CurrentUser { get; private set;  }
    public bool IsLoggedIn => CurrentUser != null;
    public void Login(User user)
    {
        CurrentUser = user ?? throw new ArgumentNullException(nameof(user));
    }
    public void Logout() 
    {
        CurrentUser = null;
    }
}
