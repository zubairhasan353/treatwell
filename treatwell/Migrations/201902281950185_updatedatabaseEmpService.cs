namespace treatwell.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedatabaseEmpService : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.VenueEmployeeServices", "ApplicationUserCreatedById", "dbo.AspNetUsers");
            DropForeignKey("dbo.VenueEmployeeServices", "ApplicationUserLastUpdatedById", "dbo.AspNetUsers");
            DropForeignKey("dbo.VenueEmployeeServices", "VenueEmployeeId", "dbo.AspNetUsers");
            DropForeignKey("dbo.VenueEmployeeServices", "VenueServiceId", "dbo.VenueServices");
            DropForeignKey("dbo.EmployeeAvailabilities", "VenueEmployeeServiceId", "dbo.VenueEmployeeServices");
            DropIndex("dbo.EmployeeAvailabilities", new[] { "VenueEmployeeServiceId" });
            DropIndex("dbo.VenueEmployeeServices", new[] { "VenueEmployeeId" });
            DropIndex("dbo.VenueEmployeeServices", new[] { "VenueServiceId" });
            DropIndex("dbo.VenueEmployeeServices", new[] { "ApplicationUserCreatedById" });
            DropIndex("dbo.VenueEmployeeServices", new[] { "ApplicationUserLastUpdatedById" });
            DropTable("dbo.VenueEmployeeServices");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.VenueEmployeeServices",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        VenueEmployeeId = c.String(maxLength: 128),
                        VenueServiceId = c.Int(nullable: false),
                        ApplicationUserCreatedById = c.String(maxLength: 128),
                        ApplicationUserCreatedDate = c.DateTime(nullable: false),
                        ApplicationUserLastUpdatedById = c.String(maxLength: 128),
                        ApplicationUserLastUpdatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateIndex("dbo.VenueEmployeeServices", "ApplicationUserLastUpdatedById");
            CreateIndex("dbo.VenueEmployeeServices", "ApplicationUserCreatedById");
            CreateIndex("dbo.VenueEmployeeServices", "VenueServiceId");
            CreateIndex("dbo.VenueEmployeeServices", "VenueEmployeeId");
            CreateIndex("dbo.EmployeeAvailabilities", "VenueEmployeeServiceId");
            AddForeignKey("dbo.EmployeeAvailabilities", "VenueEmployeeServiceId", "dbo.VenueEmployeeServices", "Id", cascadeDelete: true);
            AddForeignKey("dbo.VenueEmployeeServices", "VenueServiceId", "dbo.VenueServices", "Id", cascadeDelete: true);
            AddForeignKey("dbo.VenueEmployeeServices", "VenueEmployeeId", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.VenueEmployeeServices", "ApplicationUserLastUpdatedById", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.VenueEmployeeServices", "ApplicationUserCreatedById", "dbo.AspNetUsers", "Id");
        }
    }
}
