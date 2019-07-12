namespace treatwell.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlterCustomerBooking2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.CustomerBookings", "CustomerId", "dbo.Customers");
            DropIndex("dbo.CustomerBookings", new[] { "CustomerId" });
            AddColumn("dbo.CustomerBookings", "Customer_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.CustomerBookings", "Customer_Id");
            AddForeignKey("dbo.CustomerBookings", "Customer_Id", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CustomerBookings", "Customer_Id", "dbo.AspNetUsers");
            DropIndex("dbo.CustomerBookings", new[] { "Customer_Id" });
            DropColumn("dbo.CustomerBookings", "Customer_Id");
            CreateIndex("dbo.CustomerBookings", "CustomerId");
            AddForeignKey("dbo.CustomerBookings", "CustomerId", "dbo.Customers", "Id", cascadeDelete: true);
        }
    }
}
