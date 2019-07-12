namespace treatwell.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlterBookingDaysTime : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.BookingDaysTimes", "DayID", c => c.String());
            AddColumn("dbo.BookingDaysTimes", "Day_Id", c => c.Int());
            CreateIndex("dbo.BookingDaysTimes", "Day_Id");
            AddForeignKey("dbo.BookingDaysTimes", "Day_Id", "dbo.Days", "Id");
            DropColumn("dbo.BookingDaysTimes", "DayName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.BookingDaysTimes", "DayName", c => c.String(nullable: false));
            DropForeignKey("dbo.BookingDaysTimes", "Day_Id", "dbo.Days");
            DropIndex("dbo.BookingDaysTimes", new[] { "Day_Id" });
            DropColumn("dbo.BookingDaysTimes", "Day_Id");
            DropColumn("dbo.BookingDaysTimes", "DayID");
        }
    }
}
