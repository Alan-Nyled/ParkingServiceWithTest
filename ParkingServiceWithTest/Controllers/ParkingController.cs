using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ParkingServiceWithTest.Models;

namespace ParkingServiceWithTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParkingController : ControllerBase
    {
        private DateOnly Today()
        {
            return DateOnly.FromDateTime(DateTime.Now);
        }

        [HttpPost("/")]
        public OkResult RegisterParking(string plate, string lot, string mail, string phone)
        {
           
            Parking parking = new(plate, lot, Today())
            {
                Mail = mail,
                Phone = phone
            };
            Database database = new();
            database.AddParking(parking);
            return Ok();

        }

        [HttpGet("/")]
        public IActionResult GetParking(string plate, string lot)
        {
            Database database = new();
            Parking? parking = database.GetParking(plate, lot, Today()); 
            if(parking == null)
            {
                return NotFound();
            }
            return Ok();

        }
        [HttpDelete("/")]
        public void DeleteParkings(string plate)
        {
            Database database = new();
            database.DeleteParkings(plate);
        }
    }
}
