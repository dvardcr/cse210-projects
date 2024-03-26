using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        //Shape squareShape = new Square("green", 4);

        //string squareColor = squareShape.GetColor();
        //Console.WriteLine($"Square Color: {squareColor}");
        
        //double squareArea = squareShape.GetArea();
        //Console.WriteLine($"Square Area: {squareArea}");

    List<Shape> shapes = new List<Shape>();

    shapes.Add(new Square("red", 4));
    shapes.Add(new Rectangle("blue", 4, 4));
    shapes.Add(new Circle("yellow", 4));

    foreach (Shape shape in shapes)
        {
            Console.WriteLine("Color: " + shape.GetColor());
            Console.WriteLine("Area: " + shape.GetArea());
            Console.WriteLine();
            //Console.WriteLine($"The {color} shape has an area of {area}.");
        }
    }
}