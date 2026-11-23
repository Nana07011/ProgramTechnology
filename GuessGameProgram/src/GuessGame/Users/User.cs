namespace GuessGame.Users;

public class User
{
    public Guid Id { get; }
    public string UserName { get; }
    public string Password { get; }
    public User(Guid id, string userName, string password) 
    {
        Id = id;
        UserName = userName;
        Password = password;
    }
}
