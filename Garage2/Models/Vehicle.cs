using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Garage2.Models {
    public class Vehicle {
        [Key]
        public int Id { get; set; }
        public virtual Member Owner { get; set; }
        [DisplayName("Vehicle type")]
        public virtual VehicleType Type { get; set; }
        [DisplayName("License plate")]
        [StringLength(6, ErrorMessage = "6 character! and the three first shoud be Alphabet", MinimumLength = 6)]
        public string LicensePlate { get; set; }
        public string Color { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }

        [DisplayName("Number of wheels")]
        [Range(0, 10)]
        public int WheelAmount { get; set; }
        public DateTime CheckInTime { get; set; }
    }
}