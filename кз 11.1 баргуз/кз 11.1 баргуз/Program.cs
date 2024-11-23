using System;
using System.IO;

class Program
{
    static void Main()
    {
        string filePath = "f.txt";

        try
        {
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                // Запись заголовка
                writer.WriteLine("x    sin(x)");

                // Запись значений x и sin(x)
                for (double x = 0; x <= 1.0; x += 0.1)
                {
                    writer.WriteLine($"{x:F1}  {Math.Sin(x):F4}");
                }
            }

            Console.WriteLine($"Таблица значений успешно записана в файл \"{filePath}\".");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка при записи в файл: {ex.Message}");
        }
    }
}

