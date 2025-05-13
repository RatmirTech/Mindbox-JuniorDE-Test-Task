using ShapesLibrary.Abstractions;
using ShapesLibrary.Models;
using ShapesLibrary.Utilities;

namespace ShapesLibrary.Tests.UtilitiesTests;

public class ShapeCalculatorTests
{
    [Fact]
    public void CalculateArea_WithDifferentShapes_ReturnsExpectedPolymorphicValues()
    {
        IShape circle = new Circle(2.0);
        IShape triangle = new Triangle(3.0, 4.0, 5.0);

        double circleArea = ShapeCalculator.CalculateArea(circle);
        double triangleArea = ShapeCalculator.CalculateArea(triangle);

        Assert.Equal(Math.PI * 4.0, circleArea, precision: 6);
        Assert.Equal(6.0, triangleArea, precision: 6);
    }
}