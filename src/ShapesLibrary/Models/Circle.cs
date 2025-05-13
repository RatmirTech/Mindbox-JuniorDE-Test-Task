using ShapesLibrary.Abstractions;

namespace ShapesLibrary.Models;

/// <summary>
/// Класс фигуры Круг. Реализует метод получения радиуса круга по радиусу.
/// </summary>
public class Circle : IShape
{
    /// <summary>
    /// Радиус круга. Должен быть > 0
    /// </summary>
    public double Radius { get; }

    /// <summary>
    /// Создаёт экземпляр класса Круг с заданным радиусом.
    /// </summary>
    /// <param name="radius">Радиус круга. Должен быть > 0</param>
    /// <exception cref="ArgumentException">Если радиус меньше или равен нулю</exception>
    public Circle(double radius)
    {
        if (radius <= 0)
            throw new ArgumentException("Радиус должен быть больше нуля.", nameof(radius));

        Radius = radius;
    }

    /// <summary>
    /// Создаёт экземпляр класса Круг с заданным целочисленным радиусом.
    /// </summary>
    /// <param name="radius">Радиус круга. Должен быть > 0</param>
    /// <exception cref="ArgumentException">Если радиус меньше или равен нулю</exception>
    public Circle(int radius)
        : this((double)radius)
    { }

    public double Area()
    {
        return Math.PI * Radius * Radius;
    }
}