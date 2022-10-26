namespace ParkingServiceWithTest.Models
{
    public interface IDatabase
    {
        public void AddParking(Parking parking);
        public Parking? GetParking(string plate, string lot, DateOnly date);
        public void DeleteParkings(string plate);
    }
}
