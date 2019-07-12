namespace treatwell.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DropTableColumnsinVenues : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Venues", "ApplicationUserCreatedById", "dbo.AspNetUsers");
            DropForeignKey("dbo.Venues", "ApplicationUserLastUpdatedById", "dbo.AspNetUsers");
            DropIndex("dbo.Venues", new[] { "ApplicationUserCreatedById" });
            DropIndex("dbo.Venues", new[] { "ApplicationUserLastUpdatedById" });
            DropColumn("dbo.Venues", "ApplicationUserCreatedById");
            DropColumn("dbo.Venues", "ApplicationUserCreatedDate");
            DropColumn("dbo.Venues", "ApplicationUserLastUpdatedById");
            DropColumn("dbo.Venues", "ApplicationUserLastUpdatedDate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Venues", "ApplicationUserLastUpdatedDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Venues", "ApplicationUserLastUpdatedById", c => c.String(maxLength: 128));
            AddColumn("dbo.Venues", "ApplicationUserCreatedDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Venues", "ApplicationUserCreatedById", c => c.String(maxLength: 128));
            CreateIndex("dbo.Venues", "ApplicationUserLastUpdatedById");
            CreateIndex("dbo.Venues", "ApplicationUserCreatedById");
            AddForeignKey("dbo.Venues", "ApplicationUserLastUpdatedById", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Venues", "ApplicationUserCreatedById", "dbo.AspNetUsers", "Id");
        }
    }
}
