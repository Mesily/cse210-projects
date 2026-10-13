
using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<Shape> shapes = new List<Shape>();

        shapes.Add(new Square("Red", 8));
        shapes.Add(new Rectangle("Blue", 2, 8));
        shapes.Add(new Circle("Green", 6));

        foreach (Shape shape in shapes)
    {
        string color = shape.GetColor();
        double area = shape.GetArea();

        Console.WriteLine($"The {color} shape has an area of {area}.");
    }
    }
}