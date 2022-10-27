using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ParkingServiceWithTest.Models;
using System.Text.Json.Serialization;

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
        public OkResult RegisterParking(string json) //string plate, string lot, string mail, string phone
        {
            var values = JsonConvert.DeserializeObject<Parking>(json);
           
            Parking parking = new(values.Plate, values.Lot, Today())
            {
                Mail = values.Mail,
                Phone = values.Phone
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
