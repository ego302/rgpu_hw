using System;
using System.Diagnostics;
using System.Numerics;

class Program
{
    static void Main()
    {
        Console.WriteLine("Введите максимальные значения для проверки (рекомендуется вводить значения в диапозоне 20-30):");
        Console.Write("Факториал (макс n): ");
        int factorialLimit = int.Parse(Console.ReadLine());
        Console.Write("Фибоначчи (макс n): ");
        int fibonacciLimit = int.Parse(Console.ReadLine());

        Console.WriteLine("\nВыводятся те значения n, при которых рекурсивный метод заметно уступает по скорости итеративному");

        Console.WriteLine("\nПроверка факториала:");
        Benchmark(factorialLimit, FactorialRecursive, FactorialIterative);

        Console.WriteLine("\nПроверка Фибоначчи:");
        Benchmark(fibonacciLimit, FibonacciRecursive, FibonacciIterative);
    }

    static void Benchmark(int limit, Func<int, BigInteger> recursive, Func<int, BigInteger> iterative)
    {
        for (int n = 0; n <= limit; n++)
        {
            long recTime = Measure(() => recursive(n));
            long iterTime = Measure(() => iterative(n));

            if (Math.Abs(recTime - iterTime) > 1000)
            {
                Console.WriteLine($"n={n}: Рекурсивный - {recTime} тиков, Итеративный - {iterTime} тиков");
            }
        }
    }

    static long Measure(Action action)
    {
        Stopwatch sw = Stopwatch.StartNew();
        action();
        sw.Stop();
        return sw.ElapsedTicks;
    }

    static BigInteger FactorialRecursive(int n) => n == 0 ? 1 : n * FactorialRecursive(n - 1);

    static BigInteger FactorialIterative(int n)
    {
        BigInteger res = 1;
        for (int i = 2; i <= n; i++)
            res *= i;
        return res;
    }

    static BigInteger FibonacciRecursive(int n) => n <= 1 ? n : FibonacciRecursive(n - 1) + FibonacciRecursive(n - 2);

    static BigInteger FibonacciIterative(int n)
    {
        if (n < 2) return n;

        BigInteger a = 0, b = 1;
        for (int i = 2; i <= n; i++)
        {
            (a, b) = (b, a + b);
        }
        return b;
    }
}

