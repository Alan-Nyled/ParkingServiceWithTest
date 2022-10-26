using Xunit;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using ParkingServiceWithTest;
using System.Net;

namespace ParkingServiceWithTest.Unit.Test
{
    public class EndPointTest_Should : IDisposable
    {

        private readonly HttpClient sut;
        public EndPointTest_Should()
        {
            var host = new WebApplicationFactory<Program>();
            sut = host.CreateClient();
        }
        [Fact]
        public async Task Return_200_if_licenseplate_is_parked_correct()
        {            
            var actual = await sut.GetAsync("/?plate=ab12345&lot=her");
            Assert.Equal(HttpStatusCode.OK, actual.StatusCode);
        }
        public void Dispose()
        {
            //host.Dispose();
            sut.Dispose();
        }
    }
}