namespace GuessGame.Users;
// DIP и ISP. Классы зависят от этих интерфейсов, а не классов
// Разделение интерфейсов
public interface IUserLogin
{
    User? Login(string username, string password);
    User? Register(string  username, string password);
}
