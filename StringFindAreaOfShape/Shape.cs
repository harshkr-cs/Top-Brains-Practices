using System;


interface IArea
{
    double Area();
}


abstract class Shape:IArea{
    public abstract double Area();
}

class Circle:Shape{
    double radius;
    public Circle(int r){
        radius=r;
    }
    double PI=Math.PI;
    public override double Area(){
        return Math.Round(PI*radius*radius,2);
    }
}

class Rectangle:Shape{
    double length;
    double breadth; 
    public Rectangle(double l,double b){
        length=l;
        breadth=b;
    }
 
    public override double Area(){
        return Math.Round(2*(length+breadth),2);
    }
}

class Triangle:Shape{
  
    double bas;
    double height; 
    public Triangle(double b,double h){
        bas=b;
        height=h;
    }
 
    public override double Area(){
        return Math.Round(0.5*bas*height,2);
    }
}