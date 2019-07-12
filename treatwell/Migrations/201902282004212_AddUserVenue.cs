namespace treatwell.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUserVenue : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserVenues",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        VenuesId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                        ApplicationUserCreatedById = c.String(maxLength: 128),
                        ApplicationUserCreatedDate = c.DateTime(nullable: false),
                        ApplicationUserLastUpdatedById = c.String(maxLength: 128),
                        ApplicationUserLastUpdatedDate = c.DateTime(nullable: false),
                        User_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUserCreatedById)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUserLastUpdatedById)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id)
                .ForeignKey("dbo.Venues", t => t.VenuesId, cascadeDelete: true)
                .Index(t => t.VenuesId)
                .Index(t => t.ApplicationUserCreatedById)
                .Index(t => t.ApplicationUserLastUpdatedById)
                .Index(t => t.User_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserVenues", "VenuesId", "dbo.Venues");
            DropForeignKey("dbo.UserVenues", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.UserVenues", "ApplicationUserLastUpdatedById", "dbo.AspNetUsers");
            DropForeignKey("dbo.UserVenues", "ApplicationUserCreatedById", "dbo.AspNetUsers");
            DropIndex("dbo.UserVenues", new[] { "User_Id" });
            DropIndex("dbo.UserVenues", new[] { "ApplicationUserLastUpdatedById" });
            DropIndex("dbo.UserVenues", new[] { "ApplicationUserCreatedById" });
            DropIndex("dbo.UserVenues", new[] { "VenuesId" });
            DropTable("dbo.UserVenues");
        }
    }
}
