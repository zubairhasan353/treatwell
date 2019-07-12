namespace treatwell.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlterVenueEmployeeService : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.VenueEmployeeServices", "VenueEmployeeId", "dbo.VenueEmployees");
            DropIndex("dbo.VenueEmployeeServices", new[] { "VenueEmployeeId" });
            AlterColumn("dbo.VenueEmployeeServices", "VenueEmployeeId", c => c.String(maxLength: 128));
            CreateIndex("dbo.VenueEmployeeServices", "VenueEmployeeId");
            AddForeignKey("dbo.VenueEmployeeServices", "VenueEmployeeId", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.VenueEmployeeServices", "VenueEmployeeId", "dbo.AspNetUsers");
            DropIndex("dbo.VenueEmployeeServices", new[] { "VenueEmployeeId" });
            AlterColumn("dbo.VenueEmployeeServices", "VenueEmployeeId", c => c.Int(nullable: false));
            CreateIndex("dbo.VenueEmployeeServices", "VenueEmployeeId");
            AddForeignKey("dbo.VenueEmployeeServices", "VenueEmployeeId", "dbo.VenueEmployees", "Id", cascadeDelete: true);
        }
    }
}
