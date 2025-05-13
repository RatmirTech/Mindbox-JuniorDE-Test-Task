using ShapesLibrary.Abstractions;

namespace ShapesLibrary.Models;

/// <summary>
/// Класс фигуры Круг
/// </summary>
public class Circle : IShape
{
    /// <summary>
    /// Радиус круга. Радиус должен быть > 0
    /// </summary>
    public double Radius { get; }

    /// <summary>
    /// Создаёт экземпляр класса Круг с заданным радиусом.
    /// </summary>
    /// <param name="radius">радиус круга</param>
    /// <exception cref="ArgumentException">Если радиус меньше или равен нулю</exception>
    public Circle(double radius)
    {
        if (radius <= 0)
            throw new ArgumentException("Радиус должен быть больше нуля.", nameof(radius));

        Radius = radius;
    }

    public Circle(int radius)
        : this((double)radius)
    { }

    public double Area()
    {
        return Math.PI * Radius * Radius;
    }
}