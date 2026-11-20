namespace DelegateGeneric;
internal class Program
{
    static int[] Array() => new int[] { 24, 3, 10, -7, 9 };

    static void PrintArray<T>(T[] array)
    {
        if (array is null) return;
        foreach (var i in array)
            Console.Write(i + " ");
        Console.WriteLine();
    }
    static double f1(int a, int b, int c)
    {
        return (a + b + c) / 3.0;
    }
    static void Main()
    {
        //1
        Func<int, int, int, double> testFunc = f1;
        double res = testFunc(2, 1, 1);
        Console.WriteLine(res);


        testFunc = (a, b, c) => a * b * c;
        res = testFunc(2, 1, 1);
        Console.WriteLine(res);


        testFunc = (a, b, c) => {
            int sum = a + b + c;
            return sum / 3;
        };
        res = testFunc(2, 2, 1);
        Console.WriteLine(res);

        //2
        Action<int, int> testAction = (a, b) => Console.WriteLine(a + b);
        testAction(2, 3);

        //3
        Predicate<int> testPredicate = (int a) => a > 0;

        var array = Array();
        Sorted.BubbleSort(array, (a,b) => a > b);
        PrintArray(array);
        Console.WriteLine();

        array = Array();
        Sorted.BubbleSort(array, (a, b) => a < b);
        PrintArray(array);
        Console.WriteLine();

        array = Array();
        Sorted.BubbleSort(array, (a, b) => Math.Abs(a%10) > Math.Abs(b%10));
        PrintArray(array);
        Console.WriteLine();

        array = Array();
        Sorted.UniversalSort(array, (a, b) => Math.Abs(a % 10) > Math.Abs(b % 10));
        PrintArray(array);
        Console.WriteLine();

        string[] mas = { "qweq", "123", "ASd" };
        Sorted.UniversalSort(mas, (string a,string b) => a.CompareTo(b) > 0);

        PrintArray(mas);
        Console.WriteLine();

        var task1 = Exercises.CountIf(new[] { 1, 8, 3, 10 }, x => x > 5);
        Console.WriteLine(task1);

        var task2 = Exercises.Filter(new[] {1,8,3,10}, x=> x > 5);
        PrintArray(task2);
    }
}