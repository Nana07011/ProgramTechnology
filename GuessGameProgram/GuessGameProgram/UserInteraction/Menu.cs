using GuessGameProgram.Difficulty;

namespace GuessGameProgram.UserInteraction;

public class Menu
{
    private readonly IOutput _output;
    private readonly IInput _input;

    public Menu(IOutput output, IInput input)
    {
        _output = output;
        _input = input;
    }

    public IDifficultyLevel ChooseDifficulty()
    {
        _output.WriteLine("Выберите сложность");
        _output.WriteLine("1. Легкий уровень");
        _output.WriteLine("2. Средний уровень");
        _output.WriteLine("3. Сложный уровень");
        _output.WriteLine("4. Пользовательский уровень");

        string choice = _input.ReadLine();

        switch (choice)
        {
            case "1":
                return new EasyLevel();
            case "2":
                return new MediumLevel();
            case "3":
                return new HardLevel();
            case "4":
                _output.WriteLine("Введите минимальное число для игры");
                if(!int.TryParse(_input.ReadLine(), out int min))
                {
                    _output.WriteLine("Ошибка! Выбраны настройки по умолчанию (1-50).");
                    return new MediumLevel();
                }
                _output.WriteLine("Введите максимальное число для игры");
                if (!int.TryParse(_input.ReadLine(), out int max))
                {
                    _output.WriteLine("Ошибка! Выбраны настройки по умолчанию (1-50).");
                    return new MediumLevel();
                }
                _output.WriteLine("Введите количество попыток для игры");
                if (!int.TryParse(_input.ReadLine(), out int attempts) || attempts <= 0)
                {
                    _output.WriteLine("Ошибка! Выбраны настройки по умолчанию (7)");
                    return new MediumLevel();
                }
                if (min > max)
                {
                    _output.WriteLine("Ошибка! Минимальное число должно быть меньше максимального. Выбраны настройки по умолчанию (1-50).");
                    return new MediumLevel();
                }
                return new CustomLevel(min, max, attempts);
            default:
                _output.WriteLine("Неверный ввод. Выбран уровень по умолчанию - средний");
                return new MediumLevel();
        }
    }
}
