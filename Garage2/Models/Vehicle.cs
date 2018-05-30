using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Garage2.Models {
    public class Vehicle {
        public int Id { get; set; }
        public VehicleType Type { get; set; }
        public string LicensePlate { get; set; }
        public string Color { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public int WheelAmount { get; set; }
        public DateTime CheckInTime { get; set; }
    }

    public enum VehicleType {
        Car,
        Boat,
        Plane,
        MotorCycle,
    }
}