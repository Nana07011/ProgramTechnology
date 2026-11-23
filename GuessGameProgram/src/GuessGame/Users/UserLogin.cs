using GuessGameProgram.UserInteraction;

namespace GuessGame.Users;

public class UserLogin : IUserLogin
{
    private readonly IUserRepository _userRepository;
    private readonly IOutput _output;
    public UserLogin(IUserRepository userRepository,IOutput output)
    {
        _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
        _output = output ?? throw new ArgumentNullException(nameof(output));
    }

    public User? Login(string username, string password)
    {
        if (string.IsNullOrWhiteSpace(username)) return null;
        if (string.IsNullOrWhiteSpace(password)) return null;
        User? user = _userRepository.FindUsername(username.Trim());
        if (user == null) return null;
        if(user.Password != password) return null;
        return user;
    }

    public User? Register(string username, string password)
    {
        if (string.IsNullOrWhiteSpace(username)) 
            throw new ArgumentException("Имя пользователя не может быть пустым.");
        if (string.IsNullOrWhiteSpace(username))
            throw new ArgumentException("Пароль не может быть пустым.");
        username = username.Trim();
        if (username.Contains(";") || username.Contains("\n"))
            throw new ArgumentException("Имя содержит неправильные символы.");
        if (password.Contains(";") || password.Contains("\n"))
            throw new ArgumentException("Пароль содержит неправильные символы.");
        if (_userRepository.FindUsername(username) != null)
        {
            _output.WriteLine("Пользователь с таким именем уже существует.");
            return null;
        }
        User user = new User(Guid.NewGuid(), username, password);
        _userRepository.Add(user);
        return user;
    }
}
