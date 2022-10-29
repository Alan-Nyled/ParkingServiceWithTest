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

        public string Plate { get; set; }
        public string Lot { get; set; }
        public DateOnly Date { get; set; }
        public string? Mail { get; set; }
        public string? Phone { get; set; }

        
    }
}
