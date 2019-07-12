namespace treatwell.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeleteEmployees : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.VenueEmployees", "ApplicationUserCreatedById", "dbo.AspNetUsers");
            DropForeignKey("dbo.VenueEmployees", "ApplicationUserLastUpdatedById", "dbo.AspNetUsers");
            DropIndex("dbo.VenueEmployees", new[] { "ApplicationUserCreatedById" });
            DropIndex("dbo.VenueEmployees", new[] { "ApplicationUserLastUpdatedById" });
            DropTable("dbo.VenueEmployees");
        }
        
        public override void Down()
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
                .PrimaryKey(t => t.Id);
            
            CreateIndex("dbo.VenueEmployees", "ApplicationUserLastUpdatedById");
            CreateIndex("dbo.VenueEmployees", "ApplicationUserCreatedById");
            AddForeignKey("dbo.VenueEmployees", "ApplicationUserLastUpdatedById", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.VenueEmployees", "ApplicationUserCreatedById", "dbo.AspNetUsers", "Id");
        }
    }
}
