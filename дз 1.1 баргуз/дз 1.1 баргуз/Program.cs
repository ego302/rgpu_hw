using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Введите число:");
        if (int.TryParse(Console.ReadLine(), out int limit) && limit > 1)
        {
            Console.WriteLine($"Простые числа, не превосходящие {limit}:");
            for (int i = 2; i <= limit; i++)
            {
                if (IsPrime(i))
                {
                    Console.Write(i + " ");
                }
            }
        }
        else
        {
            Console.WriteLine("Введите целое число больше 1.");
        }
    }

    static bool IsPrime(int number)
    {
        if (number < 2) return false;

        for (int i = 2; i * i <= number; i++)
        {
            if (number % i == 0)
                return false;
        }
        return true;
    }
}
