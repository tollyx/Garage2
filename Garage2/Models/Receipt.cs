using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Garage2.Models
{
    public class Receipt
    {
        public string Owner { get; set; }
        public string LicensePlate { get; set; }
        public DateTime CheckInTime { get; set; }
        public DateTime CheckOutTime { get; set; }
        public TimeSpan ParkDuration { get; set; }
        public double Price { get; set; }

    }
}