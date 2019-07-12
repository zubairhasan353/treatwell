namespace treatwell.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlterCustomerBooking4 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.CustomerBookings", name: "Customer_Id", newName: "Cust_Id");
            RenameIndex(table: "dbo.CustomerBookings", name: "IX_Customer_Id", newName: "IX_Cust_Id");
            AddColumn("dbo.CustomerBookings", "CustId", c => c.Int(nullable: false));
            DropColumn("dbo.CustomerBookings", "CustomerId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.CustomerBookings", "CustomerId", c => c.Int(nullable: false));
            DropColumn("dbo.CustomerBookings", "CustId");
            RenameIndex(table: "dbo.CustomerBookings", name: "IX_Cust_Id", newName: "IX_Customer_Id");
            RenameColumn(table: "dbo.CustomerBookings", name: "Cust_Id", newName: "Customer_Id");
        }
    }
}
