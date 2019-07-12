namespace treatwell.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlterCustomerBooking1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CustomerBookings", "FullName", c => c.String(nullable: false));
            AddColumn("dbo.CustomerBookings", "Email", c => c.String());
            AddColumn("dbo.CustomerBookings", "ContactNo", c => c.String());
            AddColumn("dbo.CustomerBookings", "IsThisForYou", c => c.String());
            AddColumn("dbo.CustomerBookings", "VisitThisSalon", c => c.String());
            AddColumn("dbo.CustomerBookings", "TotalAmount", c => c.Int(nullable: false));
            AddColumn("dbo.CustomerBookings", "PaymentMethodId", c => c.Int(nullable: false));
            CreateIndex("dbo.CustomerBookings", "PaymentMethodId");
            AddForeignKey("dbo.CustomerBookings", "PaymentMethodId", "dbo.PaymentMethods", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CustomerBookings", "PaymentMethodId", "dbo.PaymentMethods");
            DropIndex("dbo.CustomerBookings", new[] { "PaymentMethodId" });
            DropColumn("dbo.CustomerBookings", "PaymentMethodId");
            DropColumn("dbo.CustomerBookings", "TotalAmount");
            DropColumn("dbo.CustomerBookings", "VisitThisSalon");
            DropColumn("dbo.CustomerBookings", "IsThisForYou");
            DropColumn("dbo.CustomerBookings", "ContactNo");
            DropColumn("dbo.CustomerBookings", "Email");
            DropColumn("dbo.CustomerBookings", "FullName");
        }
    }
}
