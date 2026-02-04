// See https://aka.ms/new-console-template for more information
using System;
class Program
{
    static int GCD(int a,int b)
    {
        if(b==0)
        return a;
        return GCD(b,a%b);
    }
    static void Main()
    {
        string[] input=Console.ReadLine().Split();
        int a=int.Parse(input[0]);
        int b=int.Parse(input[1]);
        Console.WriteLine(GCD(a,b));
    }
}
