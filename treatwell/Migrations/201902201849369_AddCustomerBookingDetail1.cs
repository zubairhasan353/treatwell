namespace treatwell.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCustomerBookingDetail1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CustomerBookingDetails",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        CustomerBookingId = c.Int(nullable: false),
                        VenueServiceId = c.Int(nullable: false),
                        VenueEmployeeId = c.Int(nullable: false),
                        CostPrice = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.CustomerBookings", t => t.CustomerBookingId, cascadeDelete: true)
                .ForeignKey("dbo.VenueEmployees", t => t.VenueEmployeeId, cascadeDelete: true)
                .ForeignKey("dbo.VenueServices", t => t.VenueServiceId, cascadeDelete: true)
                .Index(t => t.CustomerBookingId)
                .Index(t => t.VenueServiceId)
                .Index(t => t.VenueEmployeeId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CustomerBookingDetails", "VenueServiceId", "dbo.VenueServices");
            DropForeignKey("dbo.CustomerBookingDetails", "VenueEmployeeId", "dbo.VenueEmployees");
            DropForeignKey("dbo.CustomerBookingDetails", "CustomerBookingId", "dbo.CustomerBookings");
            DropIndex("dbo.CustomerBookingDetails", new[] { "VenueEmployeeId" });
            DropIndex("dbo.CustomerBookingDetails", new[] { "VenueServiceId" });
            DropIndex("dbo.CustomerBookingDetails", new[] { "CustomerBookingId" });
            DropTable("dbo.CustomerBookingDetails");
        }
    }
}
