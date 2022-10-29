using Xunit;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Net;
using Newtonsoft.Json;
using System.Net.Http.Json;

namespace ParkingServiceWithTest.Unit.Test
{
    public class EndPointTest_Should : IDisposable
    {
        private readonly TestData data = new();
        private readonly WebApplicationFactory<Program> host = new();
        private readonly HttpClient sut;
        public EndPointTest_Should()
        {
            sut = host.CreateClient();
        }

        [Fact]
        public async Task Return_200_OK_When_car_is_registred()
        {
            string json = JsonConvert.SerializeObject(data);
            var actual = await sut.PostAsJsonAsync("/", json);
            Assert.Equal(HttpStatusCode.OK, actual.StatusCode);
        }

        [Fact]
        public async Task Return_400_BadRequest_if_plate_not_provided()
        {
            string json = JsonConvert.SerializeObject(new TestData() { Plate = "" });
            var actual = await sut.PostAsJsonAsync("/", json);
            Assert.Equal(HttpStatusCode.BadRequest, actual.StatusCode);
        }

        [Fact]
        public async Task Return_200_OK_if_car_is_parked_legal()
        {
            string json = JsonConvert.SerializeObject(data);
            await sut.PostAsJsonAsync("/", json);            
            var actual = await sut.GetAsync($"/?plate={data.Plate}&lot={data.Lot}");
            Assert.Equal(HttpStatusCode.OK, actual.StatusCode);
        }

        [Fact]
        public async Task Return_200_OK_when_delete_all_parkings_for_specific_car()
        {
            var actual = await sut.DeleteAsync($"/?plate={data.Plate}");
            Assert.Equal(HttpStatusCode.OK, actual.StatusCode);
        }

        [Fact]
        public async Task Return_400_NotFound_if_car_is_parked_illegal()
        {
            await sut.DeleteAsync($"/?plate={data.Plate}");
            var actual = await sut.GetAsync($"/?plate={data.Plate}&lot={data.Lot}");
            Assert.Equal(HttpStatusCode.NotFound, actual.StatusCode);
        }
        public void Dispose()
        {
            host.Dispose();
            sut.Dispose();
        }
    }
}