namespace GuessGameProgram.UserInteraction;
// ISP и DIP. Реализует 1 метод
// Классы зависят от этого интерфейса а не консоли
public interface IInput
{
    string ReadLine();
}
