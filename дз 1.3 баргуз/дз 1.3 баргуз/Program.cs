using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Решение уравнения вида ax^2 + bx + c = 0");

        // Ввод коэффициентов
        Console.Write("Введите коэффициент a: ");
        double a = double.Parse(Console.ReadLine() ?? "0");
        Console.Write("Введите коэффициент b: ");
        double b = double.Parse(Console.ReadLine() ?? "0");
        Console.Write("Введите коэффициент c: ");
        double c = double.Parse(Console.ReadLine() ?? "0");

        SolveEquation(a, b, c);
    }

    static void SolveEquation(double a, double b, double c)
    {
        if (a != 0)
        {
            // Квадратное уравнение
            SolveQuadratic(a, b, c);
        }
        else if (b != 0)
        {
            // Линейное уравнение
            SolveLinear(b, c);
        }
        else
        {
            // Константное уравнение
            SolveConstant(c);
        }
    }

    static void SolveQuadratic(double a, double b, double c)
    {
        double discriminant = b * b - 4 * a * c;

        if (discriminant > 0)
        {
            double x1 = (-b + Math.Sqrt(discriminant)) / (2 * a);
            double x2 = (-b - Math.Sqrt(discriminant)) / (2 * a);
            Console.WriteLine($"Два корня: x1 = {x1}, x2 = {x2}");
        }
        else if (discriminant == 0)
        {
            double x = -b / (2 * a);
            Console.WriteLine($"Один корень: x = {x}");
        }
        else
        {
            Console.WriteLine("Корней нет (дискриминант < 0).");
        }
    }

    static void SolveLinear(double b, double c)
    {
        double x = -c / b;
        Console.WriteLine($"Линейное уравнение: один корень x = {x}");
    }

    static void SolveConstant(double c)
    {
        if (c == 0)
        {
            Console.WriteLine("Уравнение верно для всех значений x (бесконечно много решений).");
        }
        else
        {
            Console.WriteLine("Уравнение не имеет решений.");
        }
    }
}

