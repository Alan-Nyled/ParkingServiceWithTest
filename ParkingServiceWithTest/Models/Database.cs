using Microsoft.AspNetCore.Mvc;

namespace ParkingServiceWithTest.Models
{
    public class Database : IDatabase
    {
        private static readonly Dictionary<string, Parking> parkings = new();

        public bool AddParking(Parking parking)
        {
            string key = GenerateKey(parking.Plate, parking.Lot, parking.Date);

            if (!parkings.ContainsKey(key))
            {
                parkings.Add(key, parking);
                return true;
            }
            return false;
        }
        public Parking? GetParking(string plate, string lot, DateOnly date)
        {
            string key = GenerateKey(plate, lot, date);
            return parkings.GetValueOrDefault(key);
        }
        public bool DeleteParkings(string plate)
        {
            List<string> parkingsToDelete = new();

            foreach (Parking parking in parkings.Values)
            {
                if(parking.Plate == plate)
                {
                    string key = GenerateKey(parking.Plate, parking.Lot, parking.Date);
                    parkingsToDelete.Add(key);
                }
            }
            foreach (string key in parkingsToDelete)
            {
                parkings.Remove(key);
            }
            return true;
            
        }

        private static string GenerateKey(string plate, string lot, DateOnly date)
        {
            return plate + "#" + lot + "#" + date.ToString();
        }
    }
}
