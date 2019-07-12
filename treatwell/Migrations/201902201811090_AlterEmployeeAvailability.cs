namespace treatwell.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlterEmployeeAvailability : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.EmployeeAvailabilities", "DayID", c => c.Int(nullable: false));
            CreateIndex("dbo.EmployeeAvailabilities", "DayID");
            AddForeignKey("dbo.EmployeeAvailabilities", "DayID", "dbo.Days", "Id", cascadeDelete: true);
            DropColumn("dbo.EmployeeAvailabilities", "DayName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.EmployeeAvailabilities", "DayName", c => c.String(nullable: false));
            DropForeignKey("dbo.EmployeeAvailabilities", "DayID", "dbo.Days");
            DropIndex("dbo.EmployeeAvailabilities", new[] { "DayID" });
            DropColumn("dbo.EmployeeAvailabilities", "DayID");
        }
    }
}
