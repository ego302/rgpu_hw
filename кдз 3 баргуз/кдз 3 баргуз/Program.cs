using System;

namespace ConsoleAdventureGame
{
    class Adventure
    {
        static char[,] field;
        static int heroX, heroY;
        static readonly ConsoleColor GrassColor = ConsoleColor.Green;
        static readonly ConsoleColor RockColor = ConsoleColor.Gray;
        static readonly ConsoleColor TreeColor = ConsoleColor.White;
        static readonly ConsoleColor PadColor = ConsoleColor.Yellow;
        static readonly ConsoleColor ActivePadColor = ConsoleColor.Magenta;
        static readonly ConsoleColor HeroColor = ConsoleColor.Cyan;

        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            int currentStage = 0;
            char[][,] stages = {
                new char[,] {
                    {'#', '#', '#', '#', '#', '#', '#', '#', '#', '#'},
                    {'#', 'T', '#', '#', '#', '#', 'R', '#', '#', '#'},
                    {'#', '#', '#', '#', '#', '#', '#', '#', '#', '#'},
                    {'#', '#', '#', 'O', '#', '#', 'T', '#', '#', '#'},
                    {'#', '#', '#', '#', '#', '#', '#', '#', '#', '#'},
                    {'#', '#', '#', '#', '#', '#', '#', '#', '#', '#'},
                    {'#', '#', '#', '#', 'С', '#', '#', '#', '#', '#'},
                    {'#', '#', '#', '#', '#', '#', '#', '#', '#', '#'},
                    {'#', '#', '#', '#', '#', '#', '#', '#', '#', '#'},
                    {'#', '#', '#', '#', '#', '#', '#', '#', '#', '#'},
                },
                new char[,] {
                    {'#', '#', '#', '#', '#', '#', '#', '#', '#', '#'},
                    {'#', '#', '#', 'T', '#', '#', '#', '#', '#', '#'},
                    {'#', 'R', 'O', '#', '#', 'O', '#', 'T', '#', '#'},
                    {'#', '#', '#', '#', '#', '#', '#', '#', '#', '#'},
                    {'#', '#', '#', '#', '#', '#', '#', '#', '#', '#'},
                    {'#', '#', 'С', '#', '#', '#', '#', '#', '#', '#'},
                    {'#', '#', '#', '#', '#', '#', '#', '#', '#', '#'},
                    {'#', '#', '#', '#', '#', '#', '#', '#', '#', '#'},
                    {'#', '#', '#', '#', '#', '#', '#', '#', '#', '#'},
                    {'#', '#', '#', '#', '#', '#', '#', '#', '#', '#'},
                },
                new char[,] {
                    {'#', '#', '#', '#', '#', '#', '#', '#', '#', '#'},
                    {'#', '#', '#', '#', 'O', '#', '#', 'R', '#', '#'},
                    {'#', '#', '#', '#', 'T', '#', '#', 'T', '#', '#'},
                    {'#', '#', '#', '#', '#', '#', '#', '#', '#', '#'},
                    {'#', '#', 'T', 'O', '#', '#', 'O', '#', '#', '#'},
                    {'#', '#', 'T', '#', '#', '#', '#', '#', '#', '#'},
                    {'#', 'R', '#', '#', '#', '#', '#', '#', '#', '#'},
                    {'#', '#', '#', '#', '#', 'С', '#', '#', '#', '#'},
                    {'#', '#', '#', '#', '#', '#', '#', '#', '#', '#'},
                    {'#', '#', '#', '#', '#', '#', '#', '#', '#', '#'},
                },
            };

            while (currentStage < stages.Length)
            {
                field = stages[currentStage];
                InitializeHero();
                Console.Clear();
                while (!IsStageComplete())
                {
                    RenderField();
                    ProcessInput();
                }

                Console.Clear();
                Console.WriteLine($"Поздравляю! Уровень {currentStage + 1} завершен!");
                Console.ReadKey();
                currentStage++;
            }

            Console.Clear();
            Console.WriteLine("Урааа ты прошел все уровни!");
        }

        static void InitializeHero()
        {
            for (int y = 0; y < field.GetLength(0); y++)
            {
                for (int x = 0; x < field.GetLength(1); x++)
                {
                    if (field[y, x] == 'С')
                    {
                        heroX = x;
                        heroY = y;
                        return;
                    }
                }
            }
        }

        static void RenderField()
        {
            Console.Clear();
            for (int y = 0; y < field.GetLength(0); y++)
            {
                for (int x = 0; x < field.GetLength(1); x++)
                {
                    switch (field[y, x])
                    {
                        case '#': ApplyColor(GrassColor); Console.Write('#'); break;
                        case 'R': ApplyColor(RockColor); Console.Write('R'); break;
                        case 'T': ApplyColor(TreeColor); Console.Write('T'); break;
                        case 'O': ApplyColor(PadColor); Console.Write('O'); break;
                        case 'Ⓡ': case 'Ⓒ': ApplyColor(ActivePadColor); Console.Write(field[y, x]); break;
                        case 'C': ApplyColor(HeroColor); Console.Write('C'); break;
                        default: Console.Write(field[y, x]); break;
                    }
                }
                Console.WriteLine();
            }
        }

        static void ApplyColor(ConsoleColor color)
        {
            Console.ForegroundColor = color;
        }

        static void ProcessInput()
        {
            ConsoleKey key = Console.ReadKey(true).Key;
            int nextX = heroX, nextY = heroY;

            switch (key)
            {
                case ConsoleKey.UpArrow: nextY--; break;
                case ConsoleKey.DownArrow: nextY++; break;
                case ConsoleKey.LeftArrow: nextX--; break;
                case ConsoleKey.RightArrow: nextX++; break;
            }

            if (nextX < 0 || nextX >= field.GetLength(1) || nextY < 0 || nextY >= field.GetLength(0)) return;

            if (CanWalk(nextX, nextY))
            {
                MoveHero(nextX, nextY);
            }
            else if (field[nextY, nextX] == 'R')
            {
                int pushX = nextX + (nextX - heroX);
                int pushY = nextY + (nextY - heroY);

                if (pushX < 0 || pushX >= field.GetLength(1) || pushY < 0 || pushY >= field.GetLength(0)) return;

                if (CanPush(pushX, pushY))
                {
                    field[pushY, pushX] = field[pushY, pushX] == 'O' ? 'Ⓡ' : 'R';
                    field[nextY, nextX] = field[nextY, nextX] == 'Ⓡ' ? 'O' : '#';
                    MoveHero(nextX, nextY);
                }
            }
        }

        static bool CanWalk(int x, int y)
        {
            return x >= 0 && x < field.GetLength(1) &&
                   y >= 0 && y < field.GetLength(0) &&
                   (field[y, x] == '#' || field[y, x] == 'O');
        }

        static bool CanPush(int x, int y)
        {
            return x >= 0 && x < field.GetLength(1) &&
                   y >= 0 && y < field.GetLength(0) &&
                   (field[y, x] == '#' || field[y, x] == 'O');
        }

        static void MoveHero(int x, int y)
        {
            field[heroY, heroX] = field[heroY, heroX] == 'Ⓒ' ? 'O' : '#';
            heroX = x;
            heroY = y;
            field[heroY, heroX] = field[heroY, heroX] == 'O' ? 'Ⓒ' : 'C';
        }

        static bool IsStageComplete()
        {
            for (int y = 0; y < field.GetLength(0); y++)
            {
                for (int x = 0; x < field.GetLength(1); x++)
                {
                    if (field[y, x] == 'O') return false;
                }
            }
            return true;
        }
    }
}
