namespace treatwell.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddEmployeesandServices : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.VenueEmployees",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EmpName = c.String(nullable: false),
                        ContactNo = c.String(),
                        Email = c.String(),
                        ImagePath = c.String(),
                        ApplicationUserCreatedById = c.String(maxLength: 128),
                        ApplicationUserCreatedDate = c.DateTime(nullable: false),
                        ApplicationUserLastUpdatedById = c.String(maxLength: 128),
                        ApplicationUserLastUpdatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUserCreatedById)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUserLastUpdatedById)
                .Index(t => t.ApplicationUserCreatedById)
                .Index(t => t.ApplicationUserLastUpdatedById);
            
            CreateTable(
                "dbo.VenueEmployeeServices",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        VenueEmployeeId = c.Int(nullable: false),
                        VenueServiceId = c.Int(nullable: false),
                        ApplicationUserCreatedById = c.String(maxLength: 128),
                        ApplicationUserCreatedDate = c.DateTime(nullable: false),
                        ApplicationUserLastUpdatedById = c.String(maxLength: 128),
                        ApplicationUserLastUpdatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUserCreatedById)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUserLastUpdatedById)
                .ForeignKey("dbo.VenueEmployees", t => t.VenueEmployeeId, cascadeDelete: true)
                .ForeignKey("dbo.VenueServices", t => t.VenueServiceId, cascadeDelete: true)
                .Index(t => t.VenueEmployeeId)
                .Index(t => t.VenueServiceId)
                .Index(t => t.ApplicationUserCreatedById)
                .Index(t => t.ApplicationUserLastUpdatedById);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.VenueEmployeeServices", "VenueServiceId", "dbo.VenueServices");
            DropForeignKey("dbo.VenueEmployeeServices", "VenueEmployeeId", "dbo.VenueEmployees");
            DropForeignKey("dbo.VenueEmployeeServices", "ApplicationUserLastUpdatedById", "dbo.AspNetUsers");
            DropForeignKey("dbo.VenueEmployeeServices", "ApplicationUserCreatedById", "dbo.AspNetUsers");
            DropForeignKey("dbo.VenueEmployees", "ApplicationUserLastUpdatedById", "dbo.AspNetUsers");
            DropForeignKey("dbo.VenueEmployees", "ApplicationUserCreatedById", "dbo.AspNetUsers");
            DropIndex("dbo.VenueEmployeeServices", new[] { "ApplicationUserLastUpdatedById" });
            DropIndex("dbo.VenueEmployeeServices", new[] { "ApplicationUserCreatedById" });
            DropIndex("dbo.VenueEmployeeServices", new[] { "VenueServiceId" });
            DropIndex("dbo.VenueEmployeeServices", new[] { "VenueEmployeeId" });
            DropIndex("dbo.VenueEmployees", new[] { "ApplicationUserLastUpdatedById" });
            DropIndex("dbo.VenueEmployees", new[] { "ApplicationUserCreatedById" });
            DropTable("dbo.VenueEmployeeServices");
            DropTable("dbo.VenueEmployees");
        }
    }
}
