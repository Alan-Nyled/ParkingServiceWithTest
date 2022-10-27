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

        public string Plate { get; }
        public string Lot { get; }
        public DateOnly Date { get; }
        public string? Mail { get; set; }
        public string? Phone { get; set; }
    }
}
