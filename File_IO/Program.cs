// See https://aka.ms/new-console-template for more information
using System;
using System.IO;
class Program
{
    static void Main()
    {
        string inputFile="Log.txt";
        string outputFile="error.txt";
        try
        {
            string[] lines = File.ReadAllLines(inputFile);
            using (StreamWriter writer = new StreamWriter(outputFile))
            {
                foreach (string line in lines)
                {
                    if (line.Contains("ERROR"))
                    {
                        writer.WriteLine(line);
                    }
                }
            }
            Console.WriteLine("ERROR logs extracted successfully into error.txt");
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine("Mylog.txt file not found!");
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}