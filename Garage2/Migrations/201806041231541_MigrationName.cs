namespace Garage2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigrationName : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Vehicles", "LicensePlate", c => c.String(maxLength: 6));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Vehicles", "LicensePlate", c => c.String());
        }
    }
}
