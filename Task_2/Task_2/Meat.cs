namespace Task_2;
/// <summary>
/// Класс, представляющий мясной продукт
/// </summary>
public class Meat : Food
{
    /// <summary>
    /// Является ли мясо замороженным
    /// </summary>
    public bool IsFrozen { get; set; }
    /// <summary>
    /// Безопасно ли мясо для употребления(незамороженное мясо безопасно; замороженное — только в морозильнике)
    /// </summary>
    public bool IsSafeToEat => !IsFrozen || Storage == StorageType.Freezer;
    /// <summary>
    /// Конструктор с параметрами
    /// </summary>
    /// <param name="id">Id продукта</param>
    /// <param name="name">Название продукта</param>
    /// <param name="calories">Калорийность продукта</param>
    /// <param name="isFrozen">Является ли мясо замороженным</param>
    public Meat(int id, string name, int calories, bool isFrozen) : base(id, name, calories)
    {
        IsFrozen = isFrozen;
    }
    /// <summary>
    /// Конструктор с названием и калорийностью продукта
    /// </summary>
    /// <param name="name">Название продукта</param>
    /// <param name="calories">Калорийность</param>
    public Meat(string name, int calories) : this(0,name, calories, false)
    {
    }
    /// <summary>
    /// Употребление мясного продукта
    /// </summary>
    public override void Consume()
    {
        Console.WriteLine($"{Name} consumed.");
    }
    /// <summary>
    /// Возвращает строковое представление мясного продукта
    /// </summary>
    /// <returns>Строка с данными продукта</returns>
    public override string ToString()
    {
        return $"[Meat] {base.ToString()}";
    }
}




