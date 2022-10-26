namespace ParkingServiceWithTest.Models
{
    public class Parking
    {
        public Parking(string plate, string lot, DateOnly date)
        {
            Plate = plate;
            Lot = lot;
            Date = date;
        }

        public string Plate { get; }
        public string Lot { get; }
        public DateOnly Date { get; }
        public string? Mail { get; set; }
        public string? Phone { get; set; }

        
    }
}
