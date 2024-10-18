using System;
using System.Collections.Generic;



class Program
{
    static int rows = 30;
    static int cols = 30;
    static bool[,] grid = new bool[rows, cols];
    static HashSet<string> history = new HashSet<string>();



    static void Main()
    {
        Console.WriteLine("Поле игры 30x30. Введите координаты 13 живых клеток (x y). После каждой пары нажмите Enter:");
        for (int i = 0; i < 13; i++)
        {
            var input = Console.ReadLine().Split(' ');
            int x = int.Parse(input[0]);
            int y = int.Parse(input[1]);
            grid[x, y] = true;
        }
        while (true)
        {
            PrintGrid();
            string state = GetStateString();
            if (history.Contains(state) || NoAliveCells())
            {
                break;
            }
            history.Add(state);
            grid = GetNextGeneration();
            Console.ReadKey();
        }
    }



    static bool[,] GetNextGeneration()
    {
        bool[,] newGrid = new bool[rows, cols];
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                int aliveNeighbors = CountAliveNeighbors(i, j);
                if (grid[i, j])
                {
                    newGrid[i, j] = aliveNeighbors == 2 || aliveNeighbors == 3;
                }
                else
                {
                    newGrid[i, j] = aliveNeighbors == 3;
                }
            }
        }
        return newGrid;
    }



    static int CountAliveNeighbors(int x, int y)
    {
        int count = 0;
        for (int i = -1; i <= 1; i++)
        {
            for (int j = -1; j <= 1; j++)
            {
                if (i == 0 && j == 0) continue;
                int newX = (x + i + rows) % rows;
                int newY = (y + j + cols) % cols;
                if (grid[newX, newY]) count++;
            }
        }
        return count;
    }



    static void PrintGrid()
    {
        Console.Clear();
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                Console.Write(grid[i, j] ? "X" : ".");
            }
            Console.WriteLine();
        }
    }



    static string GetStateString()
    {
        string state = "";
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                state += grid[i, j] ? "1" : "0";
            }
        }
        return state;
    }



    static bool NoAliveCells()
    {
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                if (grid[i, j]) return false;
            }
        }
        return true;
    }
}
