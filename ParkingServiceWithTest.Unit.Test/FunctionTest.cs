using ParkingServiceWithTest.Models;
using Xunit;

namespace ParkingServiceWithTest.Unit.Test
{
    public class FunctionTest_Should
    {
        private readonly Database sut = new();
        private readonly TestData data = new();

        [Fact]
        public void Return_true_when_car_gets_parked()
        {
            bool response = sut.AddParking(new Parking(data.Plate, data.Lot, data.Date));
            Assert.True(response);
        }

        [Fact]
        public void Return_car_if_it_is_parked_legal()
        {
            sut.AddParking(new Parking(data.Plate, data.Lot, data.Date));
            Parking? response = sut.GetParking(data.Plate, data.Lot, data.Date);
            Assert.Equal(data.Plate, response?.Plate);
            sut.DeleteParkings(data.Plate);
        }

        [Fact]
        public void Return_NULL_if_car_is_parked_Illegal()
        {
            Parking? response = sut.GetParking("", "", data.Date);
            Assert.Null(response);
        }

        [Fact]
        public void Return_true_when_delete_all_parkings_for_specific_car()
        {
            bool response = sut.DeleteParkings(data.Plate);
            Assert.True(response);
        }
    }
}
