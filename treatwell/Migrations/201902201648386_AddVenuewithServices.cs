namespace treatwell.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddVenuewithServices : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Venues",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Username = c.String(nullable: false),
                        Password = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        VenueName = c.String(nullable: false),
                        Address = c.String(nullable: false),
                        Introduction = c.String(nullable: false),
                        ContactNo = c.String(),
                        ImagePath = c.String(nullable: false),
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
                "dbo.VenueServices",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        VenuesID = c.Int(nullable: false),
                        SubCategoriesId = c.Int(nullable: false),
                        CostPrice = c.Int(nullable: false),
                        ApplicationUserCreatedById = c.String(maxLength: 128),
                        ApplicationUserCreatedDate = c.DateTime(nullable: false),
                        ApplicationUserLastUpdatedById = c.String(maxLength: 128),
                        ApplicationUserLastUpdatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUserCreatedById)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUserLastUpdatedById)
                .ForeignKey("dbo.SubCategories", t => t.SubCategoriesId, cascadeDelete: true)
                .ForeignKey("dbo.Venues", t => t.VenuesID, cascadeDelete: true)
                .Index(t => t.VenuesID)
                .Index(t => t.SubCategoriesId)
                .Index(t => t.ApplicationUserCreatedById)
                .Index(t => t.ApplicationUserLastUpdatedById);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.VenueServices", "VenuesID", "dbo.Venues");
            DropForeignKey("dbo.VenueServices", "SubCategoriesId", "dbo.SubCategories");
            DropForeignKey("dbo.VenueServices", "ApplicationUserLastUpdatedById", "dbo.AspNetUsers");
            DropForeignKey("dbo.VenueServices", "ApplicationUserCreatedById", "dbo.AspNetUsers");
            DropForeignKey("dbo.Venues", "ApplicationUserLastUpdatedById", "dbo.AspNetUsers");
            DropForeignKey("dbo.Venues", "ApplicationUserCreatedById", "dbo.AspNetUsers");
            DropIndex("dbo.VenueServices", new[] { "ApplicationUserLastUpdatedById" });
            DropIndex("dbo.VenueServices", new[] { "ApplicationUserCreatedById" });
            DropIndex("dbo.VenueServices", new[] { "SubCategoriesId" });
            DropIndex("dbo.VenueServices", new[] { "VenuesID" });
            DropIndex("dbo.Venues", new[] { "ApplicationUserLastUpdatedById" });
            DropIndex("dbo.Venues", new[] { "ApplicationUserCreatedById" });
            DropTable("dbo.VenueServices");
            DropTable("dbo.Venues");
        }
    }
}
