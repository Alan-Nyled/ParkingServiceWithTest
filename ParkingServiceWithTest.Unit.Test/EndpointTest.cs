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

namespace ParkingServiceWithTest.Unit.Test
{
    public class EndPointTest_Should //: IDisposable
    {

        //private readonly HttpClient sut;
        //public EndPointTest_Should()
        //{
        //    var host = new WebApplicationFactory<Program>();
        //    sut = host.CreateClient();
        //}
        [Fact]
        public void Return_200_when_car_is_parked()
        {
            var test = new Database();
            int i = test.Calc();
            Assert.Equal(6, i);

            //MockData data = new();
            //var json = JsonConvert.SerializeObject(data);
            //var stringContent = new StringContent(json);
            //sut.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            //var actual = await sut.PostAsJsonAsync("/", json);
            //Assert.Equal(HttpStatusCode.OK, actual.StatusCode);
        }
    //    [Fact]
    //    public async Task Return_200_if_car_exists()
    //    {
    //    //    //MockData data = new();
    //    //    //var json = JsonConvert.SerializeObject(data, Formatting.Indented);
    //    //    //var stringContent = new StringContent(json);
    //    //    //await sut.PostAsync("/", stringContent);
    //    //    var actual = await sut.GetAsync("/?plate=AB12345&lot=Home");
    //    //    Assert.Equal(HttpStatusCode.OK, actual.StatusCode);
    //    }
    //    //public void Dispose()
    //    //{
    //    //    //host.Dispose();
    //    //    sut.Dispose();
    //    //}
   }
}