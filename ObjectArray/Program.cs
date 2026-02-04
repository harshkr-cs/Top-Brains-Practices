// See https://aka.ms/new-console-template for more information
using System;
class Program
{
    public static int Get_SumOnlyInt(object[] values)
    {
        int sum=0;
        foreach(object item in values)
        {
            if(item is int x)
            {
                sum+=x;
            }
        }
        return sum;
    }
    static void Main()
    {
        object[] values = { 10, "hello", true, null, 25, 5.5, 40 };
        int result = Get_SumOnlyInt(values);
        Console.WriteLine("Sum of integers: " + result);
    }
}
