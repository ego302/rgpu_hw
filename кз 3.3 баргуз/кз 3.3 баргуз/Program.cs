using System;

public class ComplexNumber
{
    // Действительная и мнимая части комплексного числа
    public double Real { get; set; }
    public double Imaginary { get; set; }

    // Конструктор для создания комплексного числа
    public ComplexNumber(double real, double imaginary)
    {
        Real = real;
        Imaginary = imaginary;
    }

    // Метод для вычисления модуля комплексного числа
    public double Modulus()
    {
        return Math.Sqrt(Real * Real + Imaginary * Imaginary);
    }

    // Метод для вычисления угла (аргумента) комплексного числа
    public double Argument()
    {
        return Math.Atan2(Imaginary, Real);
    }

    // Операция сложения двух комплексных чисел
    public static ComplexNumber operator +(ComplexNumber a, ComplexNumber b)
    {
        return new ComplexNumber(a.Real + b.Real, a.Imaginary + b.Imaginary);
    }

    // Операция вычитания двух комплексных чисел
    public static ComplexNumber operator -(ComplexNumber a, ComplexNumber b)
    {
        return new ComplexNumber(a.Real - b.Real, a.Imaginary - b.Imaginary);
    }

    // Операция умножения двух комплексных чисел
    public static ComplexNumber operator *(ComplexNumber a, ComplexNumber b)
    {
        double real = a.Real * b.Real - a.Imaginary * b.Imaginary;
        double imaginary = a.Real * b.Imaginary + a.Imaginary * b.Real;
        return new ComplexNumber(real, imaginary);
    }

    // Операция деления двух комплексных чисел
    public static ComplexNumber operator /(ComplexNumber a, ComplexNumber b)
    {
        double denominator = b.Real * b.Real + b.Imaginary * b.Imaginary;
        double real = (a.Real * b.Real + a.Imaginary * b.Imaginary) / denominator;
        double imaginary = (a.Imaginary * b.Real - a.Real * b.Imaginary) / denominator;
        return new ComplexNumber(real, imaginary);
    }

    // Возведение комплексного числа в степень
    public ComplexNumber Power(int exponent)
    {
        double modulus = this.Modulus();
        double argument = this.Argument();

        double realPart = Math.Pow(modulus, exponent) * Math.Cos(exponent * argument);
        double imaginaryPart = Math.Pow(modulus, exponent) * Math.Sin(exponent * argument);

        return new ComplexNumber(realPart, imaginaryPart);
    }

    // Извлечение корня комплексного числа
    public ComplexNumber Sqrt()
    {
        double modulus = this.Modulus();
        double argument = this.Argument();

        double realPart = Math.Sqrt(modulus) * Math.Cos(argument / 2);
        double imaginaryPart = Math.Sqrt(modulus) * Math.Sin(argument / 2);

        return new ComplexNumber(realPart, imaginaryPart);
    }

    // Переопределение ToString для корректного вывода
    public override string ToString()
    {
        if (Imaginary >= 0)
            return $"{Real} + {Imaginary}i";
        else
            return $"{Real} - {Math.Abs(Imaginary)}i";
    }
}

class Program
{
    static void Main()
    {
        // Пример использования
        ComplexNumber c1 = new ComplexNumber(5, 6);  // 5 + 6i
        ComplexNumber c2 = new ComplexNumber(1, 3);  // 1 + 3i

        Console.WriteLine($"c1 = {c1}");
        Console.WriteLine($"c2 = {c2}");

        // Сложение
        var sum = c1 + c2;
        Console.WriteLine($"c1 + c2 = {sum}");

        // Умножение
        var product = c1 * c2;
        Console.WriteLine($"c1 * c2 = {product}");

        // Деление
        var division = c1 / c2;
        Console.WriteLine($"c1 / c2 = {division}");

        // Возведение в степень
        var power = c1.Power(2);
        Console.WriteLine($"c1 ^ 2 = {power}");

        // Извлечение корня
        var sqrt = c1.Sqrt();
        Console.WriteLine($"sqrt(c1) = {sqrt}");

        // Модуль
        Console.WriteLine($"Модуль c1 = {c1.Modulus()}");

        // Угол
        Console.WriteLine($"Угол c1 = {c1.Argument()} радиан");
    }
}

