namespace treatwell.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddBookingDaysTime : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BookingDaysTimes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DayName = c.String(nullable: false),
                        StartTime = c.String(nullable: false),
                        EndTime = c.String(nullable: false),
                        VenueServiceId = c.Int(nullable: false),
                        IntervalinMinutes = c.Int(nullable: false),
                        ApplicationUserCreatedById = c.String(maxLength: 128),
                        ApplicationUserCreatedDate = c.DateTime(nullable: false),
                        ApplicationUserLastUpdatedById = c.String(maxLength: 128),
                        ApplicationUserLastUpdatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUserCreatedById)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUserLastUpdatedById)
                .ForeignKey("dbo.VenueServices", t => t.VenueServiceId, cascadeDelete: true)
                .Index(t => t.VenueServiceId)
                .Index(t => t.ApplicationUserCreatedById)
                .Index(t => t.ApplicationUserLastUpdatedById);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BookingDaysTimes", "VenueServiceId", "dbo.VenueServices");
            DropForeignKey("dbo.BookingDaysTimes", "ApplicationUserLastUpdatedById", "dbo.AspNetUsers");
            DropForeignKey("dbo.BookingDaysTimes", "ApplicationUserCreatedById", "dbo.AspNetUsers");
            DropIndex("dbo.BookingDaysTimes", new[] { "ApplicationUserLastUpdatedById" });
            DropIndex("dbo.BookingDaysTimes", new[] { "ApplicationUserCreatedById" });
            DropIndex("dbo.BookingDaysTimes", new[] { "VenueServiceId" });
            DropTable("dbo.BookingDaysTimes");
        }
    }
}
