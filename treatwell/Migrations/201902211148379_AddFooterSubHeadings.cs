namespace treatwell.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddFooterSubHeadings : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.FooterSubHeadings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SubHeading = c.String(nullable: false),
                        FooterHeadingId = c.Int(nullable: false),
                        ImagePath = c.String(),
                        PageDesc = c.String(),
                        ApplicationUserCreatedById = c.String(maxLength: 128),
                        ApplicationUserCreatedDate = c.DateTime(nullable: false),
                        ApplicationUserLastUpdatedById = c.String(maxLength: 128),
                        ApplicationUserLastUpdatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUserCreatedById)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUserLastUpdatedById)
                .ForeignKey("dbo.FooterHeadings", t => t.FooterHeadingId, cascadeDelete: true)
                .Index(t => t.FooterHeadingId)
                .Index(t => t.ApplicationUserCreatedById)
                .Index(t => t.ApplicationUserLastUpdatedById);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.FooterSubHeadings", "FooterHeadingId", "dbo.FooterHeadings");
            DropForeignKey("dbo.FooterSubHeadings", "ApplicationUserLastUpdatedById", "dbo.AspNetUsers");
            DropForeignKey("dbo.FooterSubHeadings", "ApplicationUserCreatedById", "dbo.AspNetUsers");
            DropIndex("dbo.FooterSubHeadings", new[] { "ApplicationUserLastUpdatedById" });
            DropIndex("dbo.FooterSubHeadings", new[] { "ApplicationUserCreatedById" });
            DropIndex("dbo.FooterSubHeadings", new[] { "FooterHeadingId" });
            DropTable("dbo.FooterSubHeadings");
        }
    }
}
