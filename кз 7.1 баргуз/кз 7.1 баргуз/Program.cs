using System;
using System.Numerics;

class Program
{
    static void Main()
    {
        Console.WriteLine("Введите целое число:");
        try
        {
            int result = ReadInt();
            Console.WriteLine($"Вы ввели число: {result}");
        }
        catch (ArgumentOutOfRangeException ex)
        {
            Console.WriteLine($"Ошибка: {ex.Message}");
        }
        catch (FormatException)
        {
            Console.WriteLine("Ошибка: Введено не число.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Неизвестная ошибка: {ex.Message}");
        }
    }

    static int ReadInt()
    {
        string input = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(input))
            throw new FormatException("Пустая строка не может быть числом.");

        if (!BigInteger.TryParse(input, out BigInteger value))
            throw new FormatException("Введено не число.");

        if (value > int.MaxValue)
            throw new ArgumentOutOfRangeException(null, "Число слишком большое для int.");
        if (value < int.MinValue)
            throw new ArgumentOutOfRangeException(null, "Число слишком маленькое для int.");

        return (int)value;
    }
}


