using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Garage2.Models {
    public class GarageContext : DbContext {
        public GarageContext() : base("GarageContext") { }

        public DbSet<VehicleType> VehicleTypes { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<Member> Members { get; set; }
    }
}