namespace treatwell.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateDatabase : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.FooterHeadings", "ApplicationUserCreatedById", "dbo.AspNetUsers");
            DropForeignKey("dbo.FooterHeadings", "ApplicationUserLastUpdatedById", "dbo.AspNetUsers");
            DropForeignKey("dbo.FooterSubHeadings", "ApplicationUserCreatedById", "dbo.AspNetUsers");
            DropForeignKey("dbo.FooterSubHeadings", "ApplicationUserLastUpdatedById", "dbo.AspNetUsers");
            DropForeignKey("dbo.FooterSubHeadings", "FooterHeadingId", "dbo.FooterHeadings");
            DropForeignKey("dbo.OtherPages", "ApplicationUserCreatedById", "dbo.AspNetUsers");
            DropForeignKey("dbo.OtherPages", "ApplicationUserLastUpdatedById", "dbo.AspNetUsers");
            DropForeignKey("dbo.SubPages", "ApplicationUserCreatedById", "dbo.AspNetUsers");
            DropForeignKey("dbo.SubPages", "ApplicationUserLastUpdatedById", "dbo.AspNetUsers");
            DropForeignKey("dbo.SubPages", "OtherPageId", "dbo.OtherPages");
            DropIndex("dbo.FooterHeadings", new[] { "ApplicationUserCreatedById" });
            DropIndex("dbo.FooterHeadings", new[] { "ApplicationUserLastUpdatedById" });
            DropIndex("dbo.FooterSubHeadings", new[] { "FooterHeadingId" });
            DropIndex("dbo.FooterSubHeadings", new[] { "ApplicationUserCreatedById" });
            DropIndex("dbo.FooterSubHeadings", new[] { "ApplicationUserLastUpdatedById" });
            DropIndex("dbo.OtherPages", new[] { "ApplicationUserCreatedById" });
            DropIndex("dbo.OtherPages", new[] { "ApplicationUserLastUpdatedById" });
            DropIndex("dbo.SubPages", new[] { "OtherPageId" });
            DropIndex("dbo.SubPages", new[] { "ApplicationUserCreatedById" });
            DropIndex("dbo.SubPages", new[] { "ApplicationUserLastUpdatedById" });
            DropTable("dbo.FooterHeadings");
            DropTable("dbo.FooterSubHeadings");
            DropTable("dbo.OtherPages");
            DropTable("dbo.SubPages");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.SubPages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OtherPageId = c.Int(nullable: false),
                        SubPageName = c.String(nullable: false),
                        ImagePath = c.String(),
                        SubPageDesc = c.String(),
                        ApplicationUserCreatedById = c.String(maxLength: 128),
                        ApplicationUserCreatedDate = c.DateTime(nullable: false),
                        ApplicationUserLastUpdatedById = c.String(maxLength: 128),
                        ApplicationUserLastUpdatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.OtherPages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PageName = c.String(nullable: false),
                        ImagePath = c.String(),
                        PageDesc = c.String(),
                        ApplicationUserCreatedById = c.String(maxLength: 128),
                        ApplicationUserCreatedDate = c.DateTime(nullable: false),
                        ApplicationUserLastUpdatedById = c.String(maxLength: 128),
                        ApplicationUserLastUpdatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
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
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.FooterHeadings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Heading = c.String(nullable: false),
                        ApplicationUserCreatedById = c.String(maxLength: 128),
                        ApplicationUserCreatedDate = c.DateTime(nullable: false),
                        ApplicationUserLastUpdatedById = c.String(maxLength: 128),
                        ApplicationUserLastUpdatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateIndex("dbo.SubPages", "ApplicationUserLastUpdatedById");
            CreateIndex("dbo.SubPages", "ApplicationUserCreatedById");
            CreateIndex("dbo.SubPages", "OtherPageId");
            CreateIndex("dbo.OtherPages", "ApplicationUserLastUpdatedById");
            CreateIndex("dbo.OtherPages", "ApplicationUserCreatedById");
            CreateIndex("dbo.FooterSubHeadings", "ApplicationUserLastUpdatedById");
            CreateIndex("dbo.FooterSubHeadings", "ApplicationUserCreatedById");
            CreateIndex("dbo.FooterSubHeadings", "FooterHeadingId");
            CreateIndex("dbo.FooterHeadings", "ApplicationUserLastUpdatedById");
            CreateIndex("dbo.FooterHeadings", "ApplicationUserCreatedById");
            AddForeignKey("dbo.SubPages", "OtherPageId", "dbo.OtherPages", "Id", cascadeDelete: true);
            AddForeignKey("dbo.SubPages", "ApplicationUserLastUpdatedById", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.SubPages", "ApplicationUserCreatedById", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.OtherPages", "ApplicationUserLastUpdatedById", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.OtherPages", "ApplicationUserCreatedById", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.FooterSubHeadings", "FooterHeadingId", "dbo.FooterHeadings", "Id", cascadeDelete: true);
            AddForeignKey("dbo.FooterSubHeadings", "ApplicationUserLastUpdatedById", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.FooterSubHeadings", "ApplicationUserCreatedById", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.FooterHeadings", "ApplicationUserLastUpdatedById", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.FooterHeadings", "ApplicationUserCreatedById", "dbo.AspNetUsers", "Id");
        }
    }
}
