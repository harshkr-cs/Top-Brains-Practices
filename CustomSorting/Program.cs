using System;
using System.Collections.Generic;
class Student
{
    public string Name { get; set; }
    public int Age { get; set; }
    public int Marks { get; set; }

    public Student(string name, int age, int marks){
        this.Name = name;
        this.Age = age;
        this.Marks = marks;
    }
}
class StudentComp : IComparer<Student>{
    public int Compare(Student x,Student y){
        if(x.Marks != y.Marks){
            // return y.Marks-x.Marks;
            return y.Marks.CompareTo(x.Marks);
        }
        return x.Age.CompareTo(y.Age);
    }
        
}

class Programme{
    public static void Main(string[] args){
        List<Student> students = new List<Student>
        {
            new Student("Harsh", 21, 85),
            new Student("Aman", 20, 90),
            new Student("Neha", 22, 90),
            new Student("Ravi", 19, 85)
        };

        students.Sort(new StudentComp());

        foreach (var s in students)
        {
            Console.WriteLine($"{s.Name}  Age: {s.Age}  Marks: {s.Marks}");
        }
    }
}
