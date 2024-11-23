using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Введите число n:");
        if (int.TryParse(Console.ReadLine(), out int n) && n > 0)
        {
            int steps = Steps(n);
            Console.WriteLine($"Кол-во замен для получения 1: {steps}");
        }
        else
        {
            Console.WriteLine("Введите целое положительное число");
        }
    }

    static int Steps(int n)
    {
        int steps = 0;

        while (n != 1)
        {
            if (n % 2 == 0)
            {
                n /= 2;
            }
            else
            {
                n = 3 * n + 1;
            }
            steps++;
        }

        return steps;
    }
}

