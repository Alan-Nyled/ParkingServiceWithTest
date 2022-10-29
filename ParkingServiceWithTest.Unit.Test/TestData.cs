using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public string Lot { get; set; }
        public DateOnly Date { get; set; }
        public string? Mail { get; set; }
        public string? Phone { get; set; }
    }
}
