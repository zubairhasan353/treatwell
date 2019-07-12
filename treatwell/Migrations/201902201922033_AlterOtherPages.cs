namespace treatwell.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlterOtherPages : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.OtherPages", "ApplicationUserCreatedById", c => c.String(maxLength: 128));
            AddColumn("dbo.OtherPages", "ApplicationUserCreatedDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.OtherPages", "ApplicationUserLastUpdatedById", c => c.String(maxLength: 128));
            AddColumn("dbo.OtherPages", "ApplicationUserLastUpdatedDate", c => c.DateTime(nullable: false));
            CreateIndex("dbo.OtherPages", "ApplicationUserCreatedById");
            CreateIndex("dbo.OtherPages", "ApplicationUserLastUpdatedById");
            AddForeignKey("dbo.OtherPages", "ApplicationUserCreatedById", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.OtherPages", "ApplicationUserLastUpdatedById", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OtherPages", "ApplicationUserLastUpdatedById", "dbo.AspNetUsers");
            DropForeignKey("dbo.OtherPages", "ApplicationUserCreatedById", "dbo.AspNetUsers");
            DropIndex("dbo.OtherPages", new[] { "ApplicationUserLastUpdatedById" });
            DropIndex("dbo.OtherPages", new[] { "ApplicationUserCreatedById" });
            DropColumn("dbo.OtherPages", "ApplicationUserLastUpdatedDate");
            DropColumn("dbo.OtherPages", "ApplicationUserLastUpdatedById");
            DropColumn("dbo.OtherPages", "ApplicationUserCreatedDate");
            DropColumn("dbo.OtherPages", "ApplicationUserCreatedById");
        }
    }
}
