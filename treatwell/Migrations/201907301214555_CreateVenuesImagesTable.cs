namespace treatwell.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateVenuesImagesTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.VenueImages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        VenuesId = c.Int(nullable: false),
                        ImagePath = c.String(),
                        ApplicationUserCreatedById = c.String(maxLength: 128),
                        ApplicationUserCreatedDate = c.DateTime(nullable: false),
                        ApplicationUserLastUpdatedById = c.String(maxLength: 128),
                        ApplicationUserLastUpdatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUserCreatedById)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUserLastUpdatedById)
                .ForeignKey("dbo.Venues", t => t.VenuesId, cascadeDelete: true)
                .Index(t => t.VenuesId)
                .Index(t => t.ApplicationUserCreatedById)
                .Index(t => t.ApplicationUserLastUpdatedById);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.VenueImages", "VenuesId", "dbo.Venues");
            DropForeignKey("dbo.VenueImages", "ApplicationUserLastUpdatedById", "dbo.AspNetUsers");
            DropForeignKey("dbo.VenueImages", "ApplicationUserCreatedById", "dbo.AspNetUsers");
            DropIndex("dbo.VenueImages", new[] { "ApplicationUserLastUpdatedById" });
            DropIndex("dbo.VenueImages", new[] { "ApplicationUserCreatedById" });
            DropIndex("dbo.VenueImages", new[] { "VenuesId" });
            DropTable("dbo.VenueImages");
        }
    }
}
