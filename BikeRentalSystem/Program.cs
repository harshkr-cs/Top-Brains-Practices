// See https://aka.ms/new-console-template for more information
using System;
using System.Collections.Generic;
using BikeRentalSystem;

class Program{
    public static SortedDictionary<int, Bike> bikeDetails =new SortedDictionary<int, Bike>();

    public static void Main(string[] args){

        BikeUtility utility = new BikeUtility(bikeDetails);
        int choice;

        do
        {
            Console.WriteLine("1. Add Bike Details");
            Console.WriteLine("2. Group Bikes By Brand");
            Console.WriteLine("3. Exit");
            Console.WriteLine();
            Console.WriteLine("Enter your choice");

            choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Console.WriteLine("Enter the model");
                    string model = Console.ReadLine();

                    Console.WriteLine("Enter the brand");
                    string brand = Console.ReadLine();

                    Console.WriteLine("Enter the price per day");
                    int price = int.Parse(Console.ReadLine());

                    utility.AddBikeDetails(model, brand, price);
                    Console.WriteLine("Bike details added successfully");
                    Console.WriteLine();
                    break;

                case 2:
                    SortedDictionary<string, List<Bike>> grouped =
                        utility.GroupBikesByBrand();

                    foreach (var brandGroup in grouped)
                    {
                        Console.WriteLine(brandGroup.Key);
                        foreach (var bike in brandGroup.Value)
                        {
                            Console.WriteLine(bike.Model);
                        }
                        Console.WriteLine();
                    }
                    break;

                case 3:
                    break;
            }

        }while (choice != 3);
  

    }
}
