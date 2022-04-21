using System;
using Abstract;

namespace Console
{

    public interface IShape
    {
        string GetShape();
    }
    public abstract class Shape
    {
        public abstract string GetShape();
    }
    public class Triangle : IShape
    {
        public string GetShape()
        {
            return "triangle";
        }
    }

    public class Circle : IShape
    {
        public string GetShape()
        {
            return "circle";
        }
    }

    public class ShapeController
    {
        IShape _IShape;
        public ShapeController(IShape IShape)
        {
            _IShape = IShape;
        }

        public string Get()
        {
            return _IShape.GetShape();
        }
    }
    public class Program
    {
        static void Main(string[] args)
        {
            IShape shape = new Triangle();
            ShapeController contrl = new ShapeController(shape);

            System.Console.WriteLine(contrl.Get());

            TestAbs test = new TestAbs();
            System.Console.WriteLine(test.Get());
            Coordinate  point =new Coordinate(10,20);
            System.Console.WriteLine(point.x );
            // Shape circle = new Circle();
            // System.Console.WriteLine(circle.GetShape());
            // circle = new Triangle();
            // System.Console.WriteLine(circle.GetShape());

        }
    }
}
