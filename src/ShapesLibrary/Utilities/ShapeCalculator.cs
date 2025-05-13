using ShapesLibrary.Abstractions;

namespace ShapesLibrary.Utilities;

/// <summary>
/// Класс для вычисления площади фигуры без знания типа фигуры в compile-time
/// </summary>
public static class ShapeCalculator
{
    /// <summary>
    /// Вычисляет площадь фигуры наследующей интерфейс <see cref="IShape"/>
    /// </summary>
    /// <param name="shape">Фигура</param>
    /// <returns>Площадь фигуры</returns>
    public static double CalculateArea(IShape shape)
    {
        if (shape == null)
            throw new ArgumentNullException(nameof(shape));
        return shape.Area();
    }
}