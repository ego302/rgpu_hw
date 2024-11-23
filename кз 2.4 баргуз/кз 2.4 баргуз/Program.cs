using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Введите размер массива:");
        if (int.TryParse(Console.ReadLine(), out int n) && n > 0)
        {
            int[] array = new int[n];
            Console.WriteLine("Введите элементы массива:");
            for (int i = 0; i < n; i++)
            {
                Console.Write($"Элемент {i + 1}: ");
                array[i] = int.Parse(Console.ReadLine() ?? "0");
            }

            Console.WriteLine("Исходный массив:");
            Console.WriteLine(string.Join(" ", array));

            BubbleSort(array);

            Console.WriteLine("Отсортированный массив:");
            Console.WriteLine(string.Join(" ", array));
        }
        else
        {
            Console.WriteLine("Введите положительное целое число для размера массива.");
        }
    }

    static void BubbleSort(int[] array)
    {
        int n = array.Length;
        for (int i = 0; i < n - 1; i++)
        {
            for (int j = 0; j < n - i - 1; j++)
            {
                if (array[j] > array[j + 1])
                {
                    int temp = array[j];
                    array[j] = array[j + 1];
                    array[j + 1] = temp;
                }
            }
        }
    }
}

