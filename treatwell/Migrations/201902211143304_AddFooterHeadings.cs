namespace treatwell.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddFooterHeadings : DbMigration
    {
        public override void Up()
        {
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
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUserCreatedById)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUserLastUpdatedById)
                .Index(t => t.ApplicationUserCreatedById)
                .Index(t => t.ApplicationUserLastUpdatedById);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.FooterHeadings", "ApplicationUserLastUpdatedById", "dbo.AspNetUsers");
            DropForeignKey("dbo.FooterHeadings", "ApplicationUserCreatedById", "dbo.AspNetUsers");
            DropIndex("dbo.FooterHeadings", new[] { "ApplicationUserLastUpdatedById" });
            DropIndex("dbo.FooterHeadings", new[] { "ApplicationUserCreatedById" });
            DropTable("dbo.FooterHeadings");
        }
    }
}
