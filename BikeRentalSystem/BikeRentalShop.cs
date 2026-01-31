using System;
using System.Collections.Generic;

namespace BikeRentalSystem{
    
    public class Bike{
        public string Model { get; set; }
        public string Brand { get; set; }
        public int PricePerDay { get; set; }
    }

   

    public class BikeUtility{
    // Reference to Program's dictionary
    private SortedDictionary<int, Bike> bikeDetails;

    public BikeUtility(SortedDictionary<int, Bike> bikeDetails){
        this.bikeDetails = bikeDetails;
    }

    // Method 1: Add bike details
    public void AddBikeDetails(string model, string brand, int pricePerDay)
    {
        int key = bikeDetails.Count + 1;

        Bike bike = new Bike
        {
            Model = model,
            Brand = brand,
            PricePerDay = pricePerDay
        };

        bikeDetails.Add(key, bike);
    }

    // Method 2: Group bikes by brand
    public SortedDictionary<string, List<Bike>> GroupBikesByBrand(){
        SortedDictionary<string, List<Bike>> result =
            new SortedDictionary<string, List<Bike>>();

        foreach (var item in bikeDetails.Values){
            if (!result.ContainsKey(item.Brand))
            {
                result[item.Brand] = new List<Bike>();
            }
            result[item.Brand].Add(item);
        }

        return result;
    }
}


}
