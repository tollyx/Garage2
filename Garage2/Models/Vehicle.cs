using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace Garage2.Models {
    public class Vehicle {
        public int Id { get; set; }
        [DisplayName("Vehicle type")]
        public VehicleType Type { get; set; }
        [DisplayName("License plate")]
        public string LicensePlate { get; set; }
        public string Color { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        [DisplayName("Number of wheels")]
        public int WheelAmount { get; set; }
        public DateTime CheckInTime { get; set; }
    }

    public enum VehicleType {
        Boat,
        Car,
        MotorCycle,
        Plane,
    }
}