using Xunit;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using ParkingServiceWithTest;
using System.Net;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Net.Http.Json;
using System.Net.Http.Headers;
using ParkingServiceWithTest.Models;
using System.Text;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ParkingServiceWithTest.Unit.Test
{
    public class EndPointTest_Should : IDisposable
    {
        private readonly Database sut = new();
        private readonly TestData data = new();
        private readonly HttpClient sutHttp;
        public EndPointTest_Should()
        {
            var host = new WebApplicationFactory<Program>();
            sutHttp = host.CreateClient();
        }

        [Fact]
        public async Task Return_200_if_car_is_parked_legal()
        {
            string json = JsonConvert.SerializeObject(data, Formatting.Indented);
            await sutHttp.PostAsJsonAsync("/", json);
            var actual = await sutHttp.GetAsync($"/?plate={data.Plate}&lot={data.Lot}");
            Assert.Equal(HttpStatusCode.OK, actual.StatusCode);
            sut.DeleteParkings(data.Plate);
        }

        [Fact]
        public void Delete_all_parkings_for_specific_car()
        {        

            //MockData data = new();
            //var json = JsonConvert.SerializeObject(data);
            //var stringContent = new StringContent(json);
            //sut.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            //var actual = await sut.PostAsJsonAsync("/", json);
            //Assert.Equal(HttpStatusCode.OK, actual.StatusCode);
        }
       
        
        public void Dispose()
        {
            //host.Dispose();
            sutHttp.Dispose();
        }
    }
}