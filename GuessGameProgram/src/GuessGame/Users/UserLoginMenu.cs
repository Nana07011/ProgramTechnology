using GuessGameProgram.UserInteraction;

namespace GuessGame.Users;
// SRP и DIP. Отвечает за общение с игроком
// зависит от интерфейсов, можно тестировать без консоли
public class UserLoginMenu
{
    private readonly IUserLogin _userLogin;
    private readonly IOutput _output;
    private readonly IInput _input;

    public UserLoginMenu(IUserLogin userLogin, IOutput output, IInput input)
    {
        _userLogin = userLogin;
        _output = output;
        _input = input;
    }
    public User? Authorize()
    {
        while (true)
        {
            _output.WriteLine("\nАвторизация");
            _output.WriteLine("Введите имя пользователя.");
            _output.WriteLine("0. Выход");

            string username = _input.ReadLine();

            if (username == "0") return null;

            _output.WriteLine("Введите пароль.");
            string password = _input.ReadLine();

            User? user = _userLogin.Login(username, password);
            if(user != null)
            {
                _output.WriteLine("Добро пожаловать, " + user.UserName);
                return user;
            }

            _output.WriteLine("Вас нет в списке. Создать аккаунт?");
            _output.WriteLine("1. Да");
            _output.WriteLine("2. Нет");

            string choice = _input.ReadLine();
            if (choice == "1")
            {
                try
                {
                    user = _userLogin.Register(username, password);
                    if (user != null)
                    {
                        _output.WriteLine("Аккаунт создан.");
                        return user;
                    }
                }
                catch (ArgumentException ex)
                {
                    _output.WriteLine(ex.Message);
                }
            }
            else if (choice == "2")
            {
                _output.WriteLine("Попробуйте ввести другое имя.");
            }
            else
            {
                _output.WriteLine("Некорректный ввод.");
            }
        }
    }
}
