namespace Garage2.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Garage2.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<Garage2.Models.GarageContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "Garage2.Models.GarageContext";
        }

        protected override void Seed(Garage2.Models.GarageContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            context.Vehicles.AddOrUpdate(v => v.Id,
                new Vehicle { Type = VehicleType.Car, LicensePlate = "HFG123", Color = "Red", Brand = "Benz", Model = "C200", WheelAmount = 4, CheckInTime = DateTime.Now },
                new Vehicle { Type = VehicleType.Boat, LicensePlate = "PKL347", Color = "Blue", Brand = "Titanic", Model = "RC3000", WheelAmount = 0, CheckInTime = DateTime.Now },
                new Vehicle { Type = VehicleType.Plane, LicensePlate = "CDR986", Color = "Green", Brand = "AirBus", Model = "JT1000", WheelAmount = 3, CheckInTime = DateTime.Now },
                new Vehicle { Type = VehicleType.MotorCycle, LicensePlate = "SLE752", Color = "Yellow", Brand = "Honda", Model = "1200", WheelAmount = 2, CheckInTime = DateTime.Now }
            );



        }
    }
}
