using ShapesLibrary.Abstractions;

namespace ShapesLibrary.Models;

/// <summary>
/// Класс фигуры Треугольник с 3 сторонами.
/// Реализует метод получения радиуса круга по 3 сторонам.
/// Проверяет является ли треугольник прямоугольным.
/// </summary>
public class Triangle : IShape
{
    /// <summary>Сторона A.</summary>
    public double A { get; }

    /// <summary>Сторона B.</summary>
    public double B { get; }

    /// <summary>Сторона C.</summary>
    public double C { get; }

    /// <summary>
    /// Создаёт экземпляр Треугольника с тремя сторонами
    /// </summary>
    /// <param name="a">Сторона A, > 0</param>
    /// <param name="b">Сторона B, > 0</param>
    /// <param name="c">Сторона C, > 0</param>
    /// <exception cref="ArgumentException">Если любая сторона = 0 или нарушено правило суммы двух сторон.</exception>
    public Triangle(double a, double b, double c)
    {
        if (a <= 0)
            throw new ArgumentException("Сторона A должна быть больше нуля.", nameof(a));

        if (b <= 0)
            throw new ArgumentException("Сторона B должна быть больше нуля.", nameof(b));

        if (c <= 0)
            throw new ArgumentException("Сторона C должна быть больше нуля.", nameof(c));

        if (a + b <= c)
            throw new ArgumentException("Сумма сторон A и B должна быть больше стороны C.");

        if (a + c <= b)
            throw new ArgumentException("Сумма сторон A и C должна быть больше стороны B.");

        if (b + c <= a)
            throw new ArgumentException("Сумма сторон B и C должна быть больше стороны A.");

        A = a;
        B = b;
        C = c;
    }

    /// <summary>
    /// Создаёт экземпляр Треугольника с тремя сторонами с целочисленными значениями
    /// </summary>
    /// <param name="a">Сторона A, > 0</param>
    /// <param name="b">Сторона B, > 0</param>
    /// <param name="c">Сторона C, > 0</param>
    /// <exception cref="ArgumentException">Если любая сторона = 0 или нарушено правило суммы двух сторон.</exception>
    public Triangle(int a, int b, int c)
        : this((double)a, (double)b, (double)c)
    { }

    public double Area()
    {
        double halfMeter = (A + B + C) / 2;
        return Math.Sqrt(halfMeter * (halfMeter - A) * (halfMeter - B) * (halfMeter - C));
    }

    /// <summary>
    /// Проверяет, является ли треугольник прямоугольным
    /// </summary>
    /// <returns>True, если треугольник прямоугольный</returns>
    /// <param name="correction">погрешность которую можно допустить из за <see langword="double"/></param>
    public bool IsRight(double correction = 1e-6)
    {
        var s = new[] { A, B, C };
        Array.Sort(s);
        return Math.Abs(s[0] * s[0] + s[1] * s[1] - s[2] * s[2]) <= correction;
    }
}