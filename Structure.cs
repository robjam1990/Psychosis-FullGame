using System;

namespace Structures
{
    class Program
    {
        static void Main(string[] args)
        {
            // Creating a point object and two rectangle objects
            Point originOne = new Point(23, 94);
            Rectangle rectOne = new Rectangle(originOne, 100, 200);
            Rectangle rectTwo = new Rectangle(50, 100);
            Rectangle rect = new Rectangle();

            // Displaying rectOne's width, height, and area
            Console.WriteLine("Width of rectOne: " + rectOne.width);
            Console.WriteLine("Height of rectOne: " + rectOne.height);
            Console.WriteLine("Area of rectOne: " + rectOne.getArea());

            // Setting rectTwo's position
            rectTwo.origin = originOne;

            // Displaying rectTwo's position
            Console.WriteLine("X Position of rectTwo: " + rectTwo.origin.x);
            Console.WriteLine("Y Position of rectTwo: " + rectTwo.origin.y);

            // Moving rectTwo and displaying its new position
            rectTwo.move(40, 72);
            Console.WriteLine("X Position of rectTwo: " + rectTwo.origin.x);
            Console.WriteLine("Y Position of rectTwo: " + rectTwo.origin.y);

            // Creating an instance of class Complex invoking the constructor
            Complex myComplexNumber = new Complex();

            // Calling SetValue method using the instance myComplexNumber
            // Setting values of real to 2 and imaginary to 3
            myComplexNumber.SetValue(2, 3);

            // Displaying values of real and imaginary parts
            myComplexNumber.DisplayValue();
        }
    }

    // Point class with constructor
    class Point
    {
        public int x = 0;
        public int y = 0;

        public Point(int a, int b)
        {
            x = a;
            y = b;
        }
    }

    // Rectangle class with constructors and methods
    class Rectangle
    {
        public int width = 0;
        public int height = 0;
        public Point origin;

        public Rectangle()
        {
            origin = new Point(0, 0);
        }

        public Rectangle(Point p)
        {
            origin = p;
        }

        public Rectangle(int w, int h)
        {
            origin = new Point(0, 0);
            width = w;
            height = h;
        }

        public Rectangle(Point p, int w, int h)
        {
            origin = p;
            width = w;
            height = h;
        }

        public void move(int x, int y)
        {
            origin.x = x;
            origin.y = y;
        }

        public int getArea()
        {
            return width * height;
        }
    }

    // Complex class with constructor, method, and destructor
    class Complex
    {
        private int realNum, imaginaryNum;

        public Complex()
        {
            realNum = 0;
            imaginaryNum = 0;
        }

        public void SetValue(int real, int imaginary)
        {
            realNum = real;
            imaginaryNum = imaginary;
        }

        public void DisplayValue()
        {
            Console.WriteLine("Real = " + realNum);
            Console.WriteLine("Imaginary = " + imaginaryNum);
        }

        ~Complex()
        {
            Console.WriteLine("Destructor was called");
        }
    }
}
