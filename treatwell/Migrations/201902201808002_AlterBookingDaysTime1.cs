namespace treatwell.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlterBookingDaysTime1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.BookingDaysTimes", "Day_Id", "dbo.Days");
            DropIndex("dbo.BookingDaysTimes", new[] { "Day_Id" });
            DropColumn("dbo.BookingDaysTimes", "DayID");
            RenameColumn(table: "dbo.BookingDaysTimes", name: "Day_Id", newName: "DayID");
            AlterColumn("dbo.BookingDaysTimes", "DayID", c => c.Int(nullable: false));
            AlterColumn("dbo.BookingDaysTimes", "DayID", c => c.Int(nullable: false));
            CreateIndex("dbo.BookingDaysTimes", "DayID");
            AddForeignKey("dbo.BookingDaysTimes", "DayID", "dbo.Days", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BookingDaysTimes", "DayID", "dbo.Days");
            DropIndex("dbo.BookingDaysTimes", new[] { "DayID" });
            AlterColumn("dbo.BookingDaysTimes", "DayID", c => c.Int());
            AlterColumn("dbo.BookingDaysTimes", "DayID", c => c.String());
            RenameColumn(table: "dbo.BookingDaysTimes", name: "DayID", newName: "Day_Id");
            AddColumn("dbo.BookingDaysTimes", "DayID", c => c.String());
            CreateIndex("dbo.BookingDaysTimes", "Day_Id");
            AddForeignKey("dbo.BookingDaysTimes", "Day_Id", "dbo.Days", "Id");
        }
    }
}
