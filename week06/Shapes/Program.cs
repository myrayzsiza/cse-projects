using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // create individual shapes
        Square mySquare = new Square("Red", 5);
        Rectangle myRectangle = new Rectangle("Blue", 4, 6);
        Circle myCircle = new Circle("Green", 3);

        // test each shape
        Console.WriteLine($"Square: Color={mySquare.GetColor()}, Area={mySquare.GetArea()}");
        Console.WriteLine($"Rectangle: Color={myRectangle.GetColor()}, Area={myRectangle.GetArea()}");
        Console.WriteLine($"Circle: Color={myCircle.GetColor()}, Area={myCircle.GetArea():F2}");

        // create a list to hold shapes
        List<Shape> shapes = new List<Shape>();
        shapes.Add(mySquare);
        shapes.Add(myRectangle);
        shapes.Add(myCircle);

        Console.WriteLine("\nIterating through shapes list:");
        foreach (Shape shape in shapes)
        {
            Console.WriteLine($"Shape Color={shape.GetColor()}, Area={shape.GetArea():F2}");
        }
    }
}
