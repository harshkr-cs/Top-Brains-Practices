// See https://aka.ms/new-console-template for more information
using System;
using System.Collections.Generic;
using System.Linq;

class Program{
    public static void Main(string[] args){
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
    }
}
