namespace treatwell.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlterCustomerBooking5 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.CustomerBookings", name: "Cust_Id", newName: "CustomerId");
            RenameIndex(table: "dbo.CustomerBookings", name: "IX_Cust_Id", newName: "IX_CustomerId");
            DropColumn("dbo.CustomerBookings", "CustId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.CustomerBookings", "CustId", c => c.Int(nullable: false));
            RenameIndex(table: "dbo.CustomerBookings", name: "IX_CustomerId", newName: "IX_Cust_Id");
            RenameColumn(table: "dbo.CustomerBookings", name: "CustomerId", newName: "Cust_Id");
        }
    }
}
