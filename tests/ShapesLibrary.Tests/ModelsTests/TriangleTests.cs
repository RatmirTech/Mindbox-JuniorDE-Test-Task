using ShapesLibrary.Models;

namespace ShapesLibrary.Tests.ModelsTests;

public class TriangleTests
{
    [Theory]
    [InlineData(3.0, 4.0, 5.0, 6.0)]
    [InlineData(5.0, 5.0, 6.0, 12.0)]
    public void Area_WithValidSides_ReturnsExpected(double a, double b, double c, double expected)
    {
        var triangle = new Triangle(a, b, c);
        Assert.Equal(expected, triangle.Area(), precision: 6);
    }

    [Theory]
    [InlineData(3, 4, 5)]
    [InlineData(5, 5, 6)]
    public void Area_WithValidIntSides_ReturnsExpected(int a, int b, int c)
    {
        var triangle = new Triangle(a, b, c);
        double expected = new Triangle((double)a, (double)b, (double)c).Area();
        Assert.Equal(expected, triangle.Area(), precision: 6);
    }

    [Theory]
    [InlineData(0, 1, 1)]
    [InlineData(1, 0, 1)]
    [InlineData(1, 1, 0)]
    [InlineData(-1, 1, 1)]
    [InlineData(1, -1, 1)]
    [InlineData(1, 1, -1)]
    public void Constructor_WithNonPositiveSide_ThrowsArgumentException(double a, double b, double c)
    {
        Assert.Throws<ArgumentException>(() => new Triangle(a, b, c));
    }

    [Theory]
    [InlineData(1.0, 2.0, 3.5)]
    [InlineData(1.0, 3.5, 2.0)]
    [InlineData(3.5, 1.0, 2.0)]
    public void Constructor_WithInvalidTriangleInequality_ThrowsArgumentException(double a, double b, double c)
    {
        Assert.Throws<ArgumentException>(() => new Triangle(a, b, c));
    }

    [Theory]
    [InlineData(3.0, 4.0, 5.0, true)]
    [InlineData(5.0, 5.0, 6.0, false)]
    public void IsRight_ReturnsCorrect(double a, double b, double c, bool expected)
    {
        var triangle = new Triangle(a, b, c);
        Assert.Equal(expected, triangle.IsRight());
    }

    [Theory]
    [InlineData(3, 4, 5, true)]
    [InlineData(3.0000001, 4, 5, true)]
    public void IsRight_WithSmallFloatingPointError_ShouldReturnCorrectResult(double a, double b, double c, bool expected)
    {
        var triangle = new Triangle(a, b, c);
        Assert.Equal(expected, triangle.IsRight());
    }

    [Theory]
    [InlineData(3, 4, 5.0000001, false)]
    public void IsRight_WithAlmostRightTriangle_ShouldReturnFalse(double a, double b, double c, bool expected)
    {
        var triangle = new Triangle(a, b, c);
        Assert.Equal(expected, triangle.IsRight());
    }
}