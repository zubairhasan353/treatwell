namespace treatwell.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlterCustomerBookingDetail : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.CustomerBookingDetails", "VenueEmployeeId", "dbo.VenueEmployees");
            DropIndex("dbo.CustomerBookingDetails", new[] { "VenueEmployeeId" });
            AlterColumn("dbo.CustomerBookingDetails", "VenueEmployeeId", c => c.String(maxLength: 128));
            CreateIndex("dbo.CustomerBookingDetails", "VenueEmployeeId");
            AddForeignKey("dbo.CustomerBookingDetails", "VenueEmployeeId", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CustomerBookingDetails", "VenueEmployeeId", "dbo.AspNetUsers");
            DropIndex("dbo.CustomerBookingDetails", new[] { "VenueEmployeeId" });
            AlterColumn("dbo.CustomerBookingDetails", "VenueEmployeeId", c => c.Int(nullable: false));
            CreateIndex("dbo.CustomerBookingDetails", "VenueEmployeeId");
            AddForeignKey("dbo.CustomerBookingDetails", "VenueEmployeeId", "dbo.VenueEmployees", "Id", cascadeDelete: true);
        }
    }
}
