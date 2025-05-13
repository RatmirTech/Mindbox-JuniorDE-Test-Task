using ShapesLibrary.Models;

namespace ShapesLibrary.Tests.ModelsTests;

/// <summary>
/// Покрытие тестами класса Круг
/// </summary>
public class CircleTests
{
    /// <summary>
    /// Проверка верности рассчётов при double значениях
    /// </summary>
    /// <param name="radius">заданный радиус</param>
    /// <param name="expected">ожидаемый радиус</param>
    [Theory]
    [InlineData(1.0, Math.PI)]
    [InlineData(3.5, Math.PI * 3.5 * 3.5)]
    public void Area_WithDoubleRadius_ReturnsExpected(double radius, double expected)
    {
        var circle = new Circle(radius);
        Assert.Equal(expected, circle.Area());
    }

    /// <summary>
    /// Проверка верности рассчётов при int значениях
    /// </summary>
    /// <param name="radius">заданный радиус</param>
    /// <param name="expected">ожидаемый радиус</param>
    [Theory]
    [InlineData(1, Math.PI)]
    [InlineData(3, Math.PI * 9)]
    public void Area_WithIntRadius_ReturnsExpected(int radius, double expected)
    {
        var circle = new Circle(radius);
        Assert.Equal(expected, circle.Area());
    }

    /// <summary>
    /// Проверка на обработку ошибок при <= 0 значениях
    /// </summary>
    /// <param name="radius">заданный радиус</param>
    [Theory]
    [InlineData(0)]
    [InlineData(-5)]
    public void NonPositiveRadius_ThrowsArgumentException(double radius)
    {
        Assert.Throws<ArgumentException>(() => new Circle(radius));
    }
}