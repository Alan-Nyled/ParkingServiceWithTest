using Xunit;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using ParkingServiceWithTest;

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
        public void Return_200_if_licenseplate_is_parked_correct()
        {

        }
        public void Dispose()
        {
            //this.host.Dispose();
            sut.Dispose();
        }
    }
}