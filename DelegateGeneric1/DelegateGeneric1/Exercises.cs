namespace DelegateGeneric;

public class Exercises
{
    // Сколько элементов массива удовлетворяют условию?
    // CountIF(new[] {1, 8, 3, 10}, x => x > 5 -> 2
    public static int CountIF<T>(T[] arr, Func<T, bool> condition)
    {
        if (arr is null) return 0;
        int count = 0;
        for (int i = 0; i < arr.Length; i++)
        {
            if (condition(arr[i]))
            {
                count++;
            }
        }
        return count;
    }

    // Вернуть новый массив только из подходящих элементов, порядок сохранить. 
    // Исходный массив менять нельзя
    // Filter(new[] {1, 8, 3, 10}, x => x > 5) -> {8, 10}
    // Подсказка: соберите результат в List<T>, в конце вызовите ToArray()

    
    public static T[] Filter<T>(T[] arr, Func<T, bool> condition)
        {
            if (arr == null)
                throw new ArgumentNullException(nameof(arr));
            if (condition == null)
                throw new ArgumentNullException(nameof(condition));
            var result = new List<T>();

            foreach (var item in arr)
            {
                if (condition(item))
                    result.Add(item);
            }
            return result.ToArray();
    }
}