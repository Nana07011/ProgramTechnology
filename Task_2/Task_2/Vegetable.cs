namespace Task_2;
/// <summary>
/// Класс, представляющий овощ
/// </summary>
public class Vegetable : Food
{
    /// <summary>
    /// Является ли овощ органическим
    /// </summary>
    public bool IsOrganic { get; set; }
    /// <summary>
    /// Является ли овощ низкокалорийным
    /// </summary>
    public bool IsLowCalorie => Calories < 50;
    /// <summary>
    /// Конструктор с параметрами
    /// </summary>
    /// <param name="id">Id овоща</param>
    /// <param name="name">Название продукта</param>
    /// <param name="calories">Калорийность продукта</param>
    /// <param name="isOrganic">Является ли овощ органическим</param>
    public Vegetable(int id, string name, int calories, bool isOrganic) : base(id, name, calories)
    {
        IsOrganic = isOrganic;
    }
    /// <summary>
    /// Конструктор с названием и калорийностью
    /// </summary>
    /// <param name="name">Название продукта</param>
    /// <param name="calories">Калорийность продукта</param>
    public Vegetable(string name, int calories) : this(0, name, calories, false) 
    { 
    }
    /// <summary>
    /// Конструктор с названием
    /// </summary>
    /// <param name="name">Название продукта</param>
    public Vegetable(string name) : this(0, name, 0, false)
    {
    }
    /// <summary>
    /// Употребление овоща
    /// </summary>
    public override void Consume()
    {
        Console.WriteLine($"{Name} consumed.");
    }
    /// <summary>
    /// Возвращает строковое представление овоща
    /// </summary>
    /// <returns>Строка с данными продукта</returns>
    public override string ToString()
    {
        return $"[Vegetable] {base.ToString()}";
    }
}

