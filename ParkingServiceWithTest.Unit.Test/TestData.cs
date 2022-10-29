namespace ParkingServiceWithTest.Unit.Test
{
    internal class TestData
    {
        public TestData()
        {
            Plate = "AB12345";
            Lot = "Home";
            Date = DateOnly.FromDateTime(DateTime.Now);
        }

        public string Plate { get; set; }
        public string Lot { get; }
        public DateOnly Date { get; }
    }
}
