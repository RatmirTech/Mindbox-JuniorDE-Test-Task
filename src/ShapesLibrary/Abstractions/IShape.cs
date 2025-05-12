namespace ShapesLibrary.Abstractions;

/// <summary>
/// Интерфейс для фигур
/// </summary>
public interface IShape
{
    /// <summary>
    /// Вычислить радиус фигуры
    /// </summary>
    /// <returns>Площадь фигуры</returns>
    double Area();
}