using System.ComponentModel;

namespace DelegateGeneric;

public class Exercises
{
    public static int CountIf<T>(T[] arr, Func<T, bool> condition)
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
    public static T[] Filter<T>(T[] arr, Func<T, bool> condition)
    {
        if (arr is null) return new T[0];
        List<T> list = new List<T>();
        for(int i = 0; i < arr.Length; i++)
        {
            if (condition(arr[i]))
            {
                list.Add(arr[i]);
            }
        }
        return list.ToArray();
    }
}
