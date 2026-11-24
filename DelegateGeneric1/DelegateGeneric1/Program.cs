using DelegateGeneric;

namespace DelegateGeneriс1
{
    internal class Program
    {
        static int[] Array() => new int[] { 24, 3, 10, -7, 9 };

        static void PrintArray<T>(T[] array)
        {
            if (array is null) return;
            foreach (var item in array)
                Console.Write(item + " ");
            Console.WriteLine();
        }

        static double f1(int a, int b, int c)
        {
            return (a + b + c) / 3.0;
        }

        static void Main(string[] args)
        {
            //1
            Func<int, int, int, double> testFunc = f1;
            double res = testFunc(2, 1, 1);
            Console.WriteLine(res);

            testFunc = (a, b, c) => a * b * c;
            res = testFunc(2, 1, 1);
            Console.WriteLine(res);

            testFunc = (a, b, c) =>
            {
                int sum = a + b + c;
                return sum / 3.0;
            };
            res = testFunc(2, 1, 1);
            Console.WriteLine(res);

            // 2
            Action<int, int> tastAction = (a, b) => Console.WriteLine(a + b);

            tastAction(2, 3);

            // 3
            Predicate<int> testPredicate = (int a) => a > 0;

            Console.WriteLine();
            var array = Array();
            Sorted.BubbleSort(array, (a, b) => a > b);

            PrintArray(array);
            Console.WriteLine();

            array = Array();
            Sorted.BubbleSort(array, (a, b) => a < b);
            PrintArray(array);
            Console.WriteLine();
            array = Array();
            Sorted.BubbleSort(array, (a, b) => Math.Abs(a % 10) > Math.Abs(b % 10));
            PrintArray(array);

            Console.WriteLine("");

            array = Array();
            Sorted.BubbleSort(array, (a, b) => Math.Abs(a % 10) > Math.Abs(b % 10));
            PrintArray(array);
            Console.WriteLine();

            string[] mas = { "qwer", "123", "Asd" };
            Sorted.UniversalSort(mas, (string a, string b) => a.CompareTo(b) > 0);
            PrintArray(mas);
            Console.WriteLine();

            // 1
            int[] number = { 1, 8, 3, 10 };
            int result = Exercises.CountIF(number, x => x > 5);
            Console.WriteLine(result);

            // 2
            int[] arr = { 1, 8, 3, 10 };
            int[] filtered = Exercises.Filter(arr, x => x > 5);
            PrintArray(filtered);

        }
    }
}