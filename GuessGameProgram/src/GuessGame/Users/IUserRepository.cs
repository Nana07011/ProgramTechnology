namespace GuessGame.Users;
// DIP и ISP. Классы зависят от этих интерфейсов, а не классов
// Разделение интерфейсов
public interface IUserRepository
{
    User? FindUsername(string username);
    void Add(User user);
    List<User> GetAll();
}
