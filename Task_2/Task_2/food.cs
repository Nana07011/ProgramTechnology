namespace Task_2;
/// <summary>
/// Базовый абстрактный класс, представляющий продукт.
/// </summary>
public abstract class Food
{
    private int _id;
    /// <summary>
    /// Название продукта
    /// </summary>
    public string Name { get; set; }
    /// <summary>
    /// Калорийность продукта
    /// </summary>
    public int Calories { get; set; }
    /// <summary>
    /// Тип хранения продукта. По умолчанию Room
    /// </summary>
    public StorageType Storage { get; set; } = StorageType.Room;
    /// <summary>
    /// Калорийность на 100 грамм продукта
    /// </summary>
    public double CaloriesPer100g => Calories / 100.0;
    /// <summary>
    /// Id продукта только для чтения
    /// </summary>
    public int Id => _id;
    /// <summary>
    /// Конструктор с параметрами
    /// </summary>
    /// <param name="id">Id продукта</param>
    /// <param name="name">Название продукта</param>
    /// <param name="calories">Калорийность продукта</param>
    public Food(int id, string name, int calories)
    {
        _id = id;
        Name = name;
        Calories = calories;
    }
    /// <summary>
    /// Конструктор, создающий продукт с Id по умолчанию и нулевой калорийностью
    /// </summary>
    /// <param name="name">Название продукта</param>
    public Food(string name) : this(0, name, 0)
    {
    }
    /// <summary>
    /// Абстрактный метод, описывающий употребление продукта
    /// </summary>
    public abstract void Consume();
    /// <summary>
    /// Возвращает строковое представление продукта
    /// </summary>
    /// <returns>Строка с названием, калорийностью и типом хранения</returns>
    public override string ToString()
    {
        return $"{Name}, {Calories} cal, storage: {Storage}";
    }
}