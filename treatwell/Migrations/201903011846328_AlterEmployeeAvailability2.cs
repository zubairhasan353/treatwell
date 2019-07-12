namespace treatwell.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlterEmployeeAvailability2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.EmployeeAvailabilities", "UserVenuesId", c => c.Int(nullable: false));
            CreateIndex("dbo.EmployeeAvailabilities", "UserVenuesId");
            AddForeignKey("dbo.EmployeeAvailabilities", "UserVenuesId", "dbo.UserVenues", "Id", cascadeDelete: true);
            DropColumn("dbo.EmployeeAvailabilities", "VenueEmployeeServiceId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.EmployeeAvailabilities", "VenueEmployeeServiceId", c => c.Int(nullable: false));
            DropForeignKey("dbo.EmployeeAvailabilities", "UserVenuesId", "dbo.UserVenues");
            DropIndex("dbo.EmployeeAvailabilities", new[] { "UserVenuesId" });
            DropColumn("dbo.EmployeeAvailabilities", "UserVenuesId");
        }
    }
}
