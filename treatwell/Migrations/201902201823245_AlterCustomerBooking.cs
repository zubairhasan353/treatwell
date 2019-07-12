namespace treatwell.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlterCustomerBooking : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CustomerBookings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CustomerId = c.Int(nullable: false),
                        EntryDate = c.DateTime(nullable: false),
                        BookingDate = c.DateTime(nullable: false),
                        BookingTime = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customers", t => t.CustomerId, cascadeDelete: true)
                .Index(t => t.CustomerId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CustomerBookings", "CustomerId", "dbo.Customers");
            DropIndex("dbo.CustomerBookings", new[] { "CustomerId" });
            DropTable("dbo.CustomerBookings");
        }
    }
}
