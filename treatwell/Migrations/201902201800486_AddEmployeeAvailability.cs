namespace treatwell.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddEmployeeAvailability : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.EmployeeAvailabilities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        VenueEmployeeServiceId = c.Int(nullable: false),
                        DayName = c.String(nullable: false),
                        StartTime = c.String(nullable: false),
                        EndTime = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.VenueEmployeeServices", t => t.VenueEmployeeServiceId, cascadeDelete: true)
                .Index(t => t.VenueEmployeeServiceId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.EmployeeAvailabilities", "VenueEmployeeServiceId", "dbo.VenueEmployeeServices");
            DropIndex("dbo.EmployeeAvailabilities", new[] { "VenueEmployeeServiceId" });
            DropTable("dbo.EmployeeAvailabilities");
        }
    }
}
