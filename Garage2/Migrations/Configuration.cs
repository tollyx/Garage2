namespace Garage2.Migrations
{
    using Garage2.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Garage2.Models.GarageContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "Garage2.Models.GarageContext";
        }

        protected override void Seed(Garage2.Models.GarageContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            var vehicleTypes = new[] {
                new VehicleType {Name = "Boat", Size = 1},
                new VehicleType {Name = "Car", Size = 1},
                new VehicleType {Name = "Motorcycle", Size = 0.5f},
                new VehicleType {Name = "Plane", Size = 2}
            };


            var members = new[] {
                new Member {Name = "Borat", PhoneNumber = "08-7778899", Email = "notv@lid.com", RegisterDate = DateTime.Now.AddDays(-1)},
                new Member {Name = "Klas-Kristian", PhoneNumber = "08-8090100", Email = "fakem@il.com", RegisterDate = DateTime.Now.AddDays(-3)},
                new Member {Name = "Bjarne", PhoneNumber = "08-1234567", Email = "nosp@m.plz", RegisterDate = DateTime.Now.AddDays(-2)},
                new Member {Name = "Lisa", PhoneNumber = "08-6001020", Email = "lisa_mail@hotmail.com", RegisterDate = DateTime.Now.AddDays(-10)},
            };

            context.Members.AddOrUpdate(m => m.Name, members);
            context.VehicleTypes.AddOrUpdate(vt => vt.Name, vehicleTypes);

            context.SaveChanges();
            
            context.Vehicles.AddOrUpdate(v => v.LicensePlate,
                new Vehicle { Owner = members[1], Type = vehicleTypes[1], LicensePlate = "HFG123", Color = "Red", Brand = "Benz", Model = "C200", WheelAmount = 4, CheckInTime = DateTime.Now },
                new Vehicle { Owner = members[0], Type = vehicleTypes[0], LicensePlate = "PKL347", Color = "Blue", Brand = "Titanic", Model = "RC3000", WheelAmount = 0, CheckInTime = DateTime.Now.AddHours(-2) },
                new Vehicle { Owner = members[3], Type = vehicleTypes[3], LicensePlate = "CDR986", Color = "Green", Brand = "AirBus", Model = "JT1000", WheelAmount = 3, CheckInTime = DateTime.Now.AddMinutes(-20) },
                new Vehicle { Owner = members[2], Type = vehicleTypes[2], LicensePlate = "SLE752", Color = "Yellow", Brand = "Honda", Model = "1200", WheelAmount = 2, CheckInTime = DateTime.Now.AddSeconds(-120) },
                new Vehicle { Owner = members[2], Type = vehicleTypes[0], LicensePlate = "WETSEA", Color = "White", Brand = "SeaBird", Model = "2000", WheelAmount = 0, CheckInTime = DateTime.Now.AddMinutes(-85) }
            );
            
        }
    }
}
