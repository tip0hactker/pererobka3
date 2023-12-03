using System;
using static System.Console;

namespace ConsoleApp1
{

    class Figure
    {
        protected string name;

        public Figure(string name) { this.name = name; }

        public void Display()
        {
            WriteLine("Figure.name = {0}", name);
        }
    }

    class Rectangle : Figure
    {
        protected double x1, y1, x2, y2;

        public Rectangle(string name, double x1, double y1, double x2, double y2) :
                base(name) 
        {
            this.x1 = x1; this.y1 = y1;
            this.x2 = x2; this.y2 = y2;
        }

        public Rectangle() : this("Rectangle", 0, 0, 1, 1) { }

        
        public new void Display()
        {
            base.Display();

            Write("Rectangle: x1 = {0:f2}, y1 = {1:f2}, ", x1, y2);
            WriteLine("x2 = {0:f2}, y2 = {1:f2}", x2, y2);
        }

        public double Area()
        {
            return Math.Abs(x1 - x2) * Math.Abs(y1 - y2);
        }
    }

 
    class RectangleColor : Rectangle
    {
        protected int color = 0;

    
        public RectangleColor(string name, double x1, double x2,
            double y1, double y2, int color) : base(name, x1, y1, x2, y2)
        {
            this.color = color;
        }

  
        public RectangleColor() : this("RectangleColor", 0, 0, 1, 1, 0) { }

     
        public new void Display()
        {
            base.Display();
            WriteLine("RectangleColor.color = {0}", color);
        }

    
        public new double Area()
        {
            return base.Area();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Figure refFg;

           
            Figure objFg = new Figure("Figure");
            Rectangle objRect = new Rectangle("Rectangle", 1, 2, 5, -4);
            RectangleColor objRectCol = new RectangleColor("RectangleColor", 1, 8, -1, 3, 2);

            refFg = objFg;
            refFg.Display(); 
            WriteLine("-----------------------");

            refFg = objRect;

            refFg.Display();
            WriteLine("-----------------------");

            try
            {
                ((Rectangle)refFg).Display();
                WriteLine("-----------------------");
            }
            catch
            {
                WriteLine("Error.");
                return;
            }

        
            Rectangle r = refFg as Rectangle; 

            if (r != null) r.Display();
            WriteLine("-----------------------");

         
            if (refFg is Rectangle)
            {
                (refFg as Rectangle).Display();
                WriteLine("-----------------------");
            }

            refFg = objRectCol;

            refFg.Display();
            WriteLine("-----------------------");

         
            try
            {
                ((Rectangle)refFg).Display();
                WriteLine("-----------------------");
            }
            catch
            {
                WriteLine("Error.");
                return;
            }

          
            if (refFg is RectangleColor)
            {
                (refFg as RectangleColor).Display();
                WriteLine("-----------------------");
            }
        }
    }
}