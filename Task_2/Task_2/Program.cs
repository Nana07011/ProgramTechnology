namespace Task_2;
/// <summary>
/// Главный класс программы.
/// </summary>
internal class Program
{
    /// <summary>
    /// Точка входа в программу.
    /// </summary>
    static void Main()
    {
        List<Food> products = new List<Food>
        {
            new Vegetable("Cucumber", 15) { IsOrganic = true },
            new Dairy("Milk", 60, DateTime.Now.AddDays(-1)) { Storage = StorageType.Fridge },
            new Meat("Chicken", 165) { IsFrozen = true, Storage = StorageType.Freezer }
        };
        foreach (Food product in products)
        {
            Console.WriteLine(product);
            Console.WriteLine($"  cal/100g: {product.CaloriesPer100g}");

            product.Consume();

            if (product is IExpirable expirable)
            {
                Console.WriteLine($"{product.Name} expired: {expirable.IsExpired()}");
            }
            else
            {
                Console.WriteLine($"{product.Name} is not expirable.");
            }

            if (product is Vegetable vegetable)
            {
                Console.WriteLine($"Organic: {vegetable.IsOrganic}, Low calorie: {vegetable.IsLowCalorie}");
            }
            else if (product is Dairy dairy)
            {
                Console.WriteLine($"Days left: {dairy.DaysLeft}");
            }
            else if (product is Meat meat)
            {
                Console.WriteLine($"Frozen: {meat.IsFrozen}, Safe to eat: {meat.IsSafeToEat}");
            }   
            Console.WriteLine();
        }
    }
}