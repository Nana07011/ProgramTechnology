namespace Task_2;
/// <summary>
/// Класс, представляющий молочный продукт
/// </summary>
public class Dairy : Food, IExpirable
{
    /// <summary>
    /// Дата истечения срока годности
    /// </summary>
    public DateTime ExpirationDate { get; set; }
    /// <summary>
    /// Количество дней до истечения срока годности
    /// </summary>
    public int DaysLeft => (ExpirationDate - DateTime.Now).Days;
    /// <summary>
    /// Конструктор с параметрами
    /// </summary>
    /// <param name="id">Id продукта</param>
    /// <param name="name">Название продукта</param>
    /// <param name="calories">Калорийность продукта</param>
    /// <param name="expirationDate">Дата истечения срока годности</param>
    public Dairy(int id, string name, int calories, DateTime expirationDate) : base(id, name, calories)
    {
        ExpirationDate = expirationDate;
    }
    /// <summary>
    /// Конструктор с названием, калорийностью и сроком годности
    /// </summary>
    /// <param name="name">Название продукта</param>
    /// <param name="calories">Калорийность продукта</param>
    /// <param name="expirationDate">Дата истечения срока годности</param>
    public Dairy(string name, int calories, DateTime expirationDate) : this(0, name, calories, expirationDate)
    {
    }
    /// <summary>
    /// Проверяет истек ли срок годности
    /// </summary>
    /// <returns>true, если срок годности истек; иначе false</returns>
    public bool IsExpired()
    {
        return DateTime.Now > ExpirationDate;
    }
    /// <summary>
    /// Употребление молочного продукта
    /// </summary>
    public override void Consume()
    {
        Console.WriteLine($"{Name} consumed.");
    }
    /// <summary>
    /// Возвращает строковое представление молочного продукта
    /// </summary>
    /// <returns>Строка с данными продукта</returns>
    public override string ToString()
    {
        return $"[Dairy] {base.ToString()}";
    }
}