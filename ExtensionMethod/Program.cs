using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        string[] items = {
            "1:Harsh",
            "2:Aman",
            "1:Ravi",
            "3:Neha",
            "2:Simran"
        };

        string[] distinctNames = items.DistinctById();

        Console.WriteLine(string.Join(", ", distinctNames));
    }
}
