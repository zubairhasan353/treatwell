namespace treatwell.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlterEmployeeAvailability1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.EmployeeAvailabilities", "ApplicationUserCreatedById", c => c.String(maxLength: 128));
            AddColumn("dbo.EmployeeAvailabilities", "ApplicationUserCreatedDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.EmployeeAvailabilities", "ApplicationUserLastUpdatedById", c => c.String(maxLength: 128));
            AddColumn("dbo.EmployeeAvailabilities", "ApplicationUserLastUpdatedDate", c => c.DateTime(nullable: false));
            CreateIndex("dbo.EmployeeAvailabilities", "ApplicationUserCreatedById");
            CreateIndex("dbo.EmployeeAvailabilities", "ApplicationUserLastUpdatedById");
            AddForeignKey("dbo.EmployeeAvailabilities", "ApplicationUserCreatedById", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.EmployeeAvailabilities", "ApplicationUserLastUpdatedById", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.EmployeeAvailabilities", "ApplicationUserLastUpdatedById", "dbo.AspNetUsers");
            DropForeignKey("dbo.EmployeeAvailabilities", "ApplicationUserCreatedById", "dbo.AspNetUsers");
            DropIndex("dbo.EmployeeAvailabilities", new[] { "ApplicationUserLastUpdatedById" });
            DropIndex("dbo.EmployeeAvailabilities", new[] { "ApplicationUserCreatedById" });
            DropColumn("dbo.EmployeeAvailabilities", "ApplicationUserLastUpdatedDate");
            DropColumn("dbo.EmployeeAvailabilities", "ApplicationUserLastUpdatedById");
            DropColumn("dbo.EmployeeAvailabilities", "ApplicationUserCreatedDate");
            DropColumn("dbo.EmployeeAvailabilities", "ApplicationUserCreatedById");
        }
    }
}
