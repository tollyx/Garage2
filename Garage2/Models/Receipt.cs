using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace Garage2.Models
{
    public class ReceiptModelView
    {
        public string Owner { get; set; }
        [DisplayName("License plate")]
        public string LicensePlate { get; set; }
        [DisplayName("Check in time")]
        public DateTime CheckInTime { get; set; }
        [DisplayName("Check out time")]
        public DateTime CheckOutTime { get; set; }
        [DisplayName("Parking time")]
        public TimeSpan ParkDuration { get; set; }
        public double Price { get; set; }

    }
}