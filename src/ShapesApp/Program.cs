using ShapesLibrary.Abstractions;
using ShapesLibrary.Models;
using ShapesLibrary.Utilities;

#region [Консольный вывод, наглядный показ работы библиотеки]

var circle = new Circle(2.5);
Console.WriteLine($"Circle (r = {circle.Radius}):");
Console.WriteLine($"  Площадь = {circle.Area():F4}\n");

var tri = new Triangle(3, 4, 5);
Console.WriteLine($"Triangle (a = {tri.A}, b = {tri.B}, c = {tri.C}):");
Console.WriteLine($"  Площадь = {tri.Area():F4}");
Console.WriteLine($"  Является прямоугольным? {tri.IsRight()}\n");


List<IShape> shapes = new() { circle, tri };
Console.WriteLine("Полиморфный обход списка IShape через ShapeCalculator:");
foreach (var shape in shapes)
{
    double area = ShapeCalculator.CalculateArea(shape);
    Console.WriteLine($"  {shape.GetType().Name}: {area:F4}");
}

var square = new Square(4);
Console.WriteLine($"\nSquare (side = {square.Side}):");
Console.WriteLine($"  Площадь = {square.Area():F4}");

#endregion

#region [Фигура тестовая чтобы показать, что можно легко создавать свои фигуры даже вне библиотеки]

public class Square : IShape
{
    public double Side { get; }
    public Square(double side)
    {
        if (side <= 0)
            throw new ArgumentException("Длина стороны должна быть больше нуля.", nameof(side));
        Side = side;
    }
    public double Area() => Side * Side;
}

#endregion