namespace Task_2;
/// <summary>
/// Интерфейс для продуктов, имеющих срок годности
/// </summary>
public interface IExpirable
{
    /// <summary>
    /// Проверяет истек ли срок годности продукта
    /// </summary>
    /// <returns>true, если срок годности истек; иначе false</returns>
    bool IsExpired();
}
