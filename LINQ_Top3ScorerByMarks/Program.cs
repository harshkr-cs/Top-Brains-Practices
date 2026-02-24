// See https://aka.ms/new-console-template for more information
using System;
using System.Collections.Generic;
using System.Linq;

class Program{
    public static void Main(string[] args){
        //Printing duplicates items
        List<string> products=new List<string>{"Pen","Book","Pen","Pencil","Book"};
        Dictionary<string,int> dict=new Dictionary<string,int>();
        //M-1(Normal)
        foreach(string product in products){
            if(dict.ContainsKey(product)){
                dict[product] += 1;
            }else{
                dict[product]=1;
            }
        }
        foreach(var it in dict){
            if(it.Value>1){
                Console.Write(it.Key + ",");
            }
        }
        Console.WriteLine();
        //M-2(LINQ)
         var duplicates = products
                            .GroupBy(p => p)
                            .Where(g => g.Count() > 1)
                            .Select(g => g.Key)
                            .ToList();

        Console.WriteLine(string.Join(", ", duplicates));


        List<string> csvData = new List<string>
        {
            "Ravi,87",
            "Kumar,98",
            "Arun,92"
        };
        //A CSV contains StudentName, Marks.Find top 3 scorers
        List<string> top3 = csvData
            .Select(line => line.Split(','))          // Split CSV
            .Select(parts => new
            {
                Name = parts[0],
                Marks = int.Parse(parts[1])
            })
            .OrderByDescending(x => x.Marks)          // Sort by marks DESC
            .Take(3)                                  // Take top 3
            .Select(x => x.Name)                      // Select only names
            .ToList();

        foreach (var name in top3)
        {
            Console.WriteLine(name);
        }

    }
}
