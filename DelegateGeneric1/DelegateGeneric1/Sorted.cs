namespace DelegateGeneric;

public class Sorted
{
    // Делегаты
    public static void BubbleSort(int[] array, Func<int, int, bool> Compare)
    {
        if (array is null) return;
        for (int i = 0; i < array.Length; i++)
        {
            for (int j = i + 1; j < array.Length; j++)
            {
                if (Compare(array[i], array[j]))
                {
                    int tmp = array[i];
                    array[i] = array[j];
                    array[j] = tmp;

                }
            }
        }
    }

    // Обобщенная сортировка
    public static void UniversalSort<T>(T[] array, Func<T, T, bool> Compare) // можно здесь написать уточнение через where
    {
        if (array is null) return;
        for (int i = 0; i < array.Length; i++)
        {
            for (int j = i + 1; j < array.Length; j++)
            {
                if (Compare(array[i], array[j]))
                {
                    T tmp = array[i];
                    array[i] = array[j];
                    array[j] = tmp;

                }
            }
        }
    }

    public static void BubbleSort2(int[] array)
    {
        if (array is null) return;
        for (int i = 0; i < array.Length; i++)
        {
            for (int j = i + 1; j < array.Length; j++)
            {
                if (array[i] % 10 < array[j] % 10)
                {
                    int tmp = array[i];
                    array[i] = array[j];
                    array[j] = tmp;

                }
            }
        }
    }
}