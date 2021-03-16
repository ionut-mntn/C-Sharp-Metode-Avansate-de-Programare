using System;
using System.Collections.Generic;

abstract class Shape
{
    public abstract void draw();
}

class Circle: Shape // e case sensitive !!
{
    public override void draw()
    {
        Console.WriteLine("Drawing circle...");
    }
}

class Rectangle: Shape
{
    public override void draw()
    {
        Console.WriteLine("Drawing rectangle...");
    }
}

namespace probaGenerics
{
    class Program
    {
        static void DrawShapes<T> (List<T> shapes) where T : Shape
        {
            shapes.ForEach(shapes => shapes.draw()) ;
        }
        static void Main(string[] args)
        {
            List<Circle> l = new List<Circle>() { new Circle(), new Circle() };
            List<Rectangle> l2 = new List<Rectangle>() { new Rectangle(), new Rectangle() };
            DrawShapes(l);            
            DrawShapes(l2);
            Console.WriteLine();
            Rectangle r = new Rectangle();
            Circle c = new Circle();
            List<Shape> l3 = new List<Shape>() { r, c };
            DrawShapes(l3);

        }
    }
}
