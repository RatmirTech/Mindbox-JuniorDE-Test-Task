# Mindbox-JuniorDE-Test-Task
Тестовое задание на позицию Junior Data Engineer в ООО Mindbox.


Задание:

Напишите на C# или Python библиотеку для поставки внешним клиентам, которая умеет вычислять площадь круга по радиусу и треугольника по трем сторонам. Дополнительно к работоспособности оценим:

Юнит-тесты
Легкость добавления других фигур
Вычисление площади фигуры без знания типа фигуры в compile-time
Проверку на то, является ли треугольник прямоугольным

## Использование (прописано в Program.cs в консольном проекте)

```csharp
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
```

## Расширение библиотеки

Чтобы добавить новую фигуру:

1. Создайте класс в папке `Models`, реализующий `IShape`:

   ```csharp
   public class Square : IShape
   {
       public double Side { get; }
       public Square(double side)
       {
           if (side <= 0) throw new ArgumentException("Side must be > 0", nameof(side));
           Side = side;
       }
       public double Area() => Side * Side;
   }
   ```
2. При необходимости добавьте тесты в `ShapesLibrary.Tests` по аналогии с `CircleTests` и `TriangleTests`.

## Юнит-тесты

Проект содержит тесты на:

* **CircleTests** — проверка расчёта площади и валидации радиуса
* **TriangleTests** — проверка формулы Герона, валидации сторон и метода `IsRight`
* **ShapeCalculatorTests** — полиморфное вычисление площади через `ShapeCalculator`
