namespace treatwell.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddSubPages : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SubPages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OtherPageid = c.Int(nullable: false),
                        SubPageName = c.String(nullable: false),
                        ImagePath = c.String(),
                        SubPageDesc = c.String(),
                        ApplicationUserCreatedById = c.String(maxLength: 128),
                        ApplicationUserCreatedDate = c.DateTime(nullable: false),
                        ApplicationUserLastUpdatedById = c.String(maxLength: 128),
                        ApplicationUserLastUpdatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUserCreatedById)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUserLastUpdatedById)
                .ForeignKey("dbo.OtherPages", t => t.OtherPageid, cascadeDelete: true)
                .Index(t => t.OtherPageid)
                .Index(t => t.ApplicationUserCreatedById)
                .Index(t => t.ApplicationUserLastUpdatedById);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SubPages", "OtherPageid", "dbo.OtherPages");
            DropForeignKey("dbo.SubPages", "ApplicationUserLastUpdatedById", "dbo.AspNetUsers");
            DropForeignKey("dbo.SubPages", "ApplicationUserCreatedById", "dbo.AspNetUsers");
            DropIndex("dbo.SubPages", new[] { "ApplicationUserLastUpdatedById" });
            DropIndex("dbo.SubPages", new[] { "ApplicationUserCreatedById" });
            DropIndex("dbo.SubPages", new[] { "OtherPageid" });
            DropTable("dbo.SubPages");
        }
    }
}
