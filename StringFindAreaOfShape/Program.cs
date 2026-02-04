// See https://aka.ms/new-console-template for more information
using System;

class Program{

    public static void Main(string[] args){
        Shape c=new Circle(7);
        Console.WriteLine("Area of circle: " +c.Area());
        Shape r=new Rectangle(7.25,5);
        Console.WriteLine("Area of rectangle: "+r.Area());
        Shape t=new Triangle(7,5);
        Console.WriteLine("Area of triangle: "+t.Area());
    }
}
