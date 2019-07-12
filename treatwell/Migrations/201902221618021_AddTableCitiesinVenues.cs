namespace treatwell.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTableCitiesinVenues : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Venues", "CityId", c => c.Int(nullable: false));
            AddColumn("dbo.Venues", "ApplicationUserCreatedById", c => c.String(maxLength: 128));
            AddColumn("dbo.Venues", "ApplicationUserCreatedDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Venues", "ApplicationUserLastUpdatedById", c => c.String(maxLength: 128));
            AddColumn("dbo.Venues", "ApplicationUserLastUpdatedDate", c => c.DateTime(nullable: false));
            CreateIndex("dbo.Venues", "CityId");
            CreateIndex("dbo.Venues", "ApplicationUserCreatedById");
            CreateIndex("dbo.Venues", "ApplicationUserLastUpdatedById");
            AddForeignKey("dbo.Venues", "ApplicationUserCreatedById", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Venues", "ApplicationUserLastUpdatedById", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Venues", "CityId", "dbo.Cities", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Venues", "CityId", "dbo.Cities");
            DropForeignKey("dbo.Venues", "ApplicationUserLastUpdatedById", "dbo.AspNetUsers");
            DropForeignKey("dbo.Venues", "ApplicationUserCreatedById", "dbo.AspNetUsers");
            DropIndex("dbo.Venues", new[] { "ApplicationUserLastUpdatedById" });
            DropIndex("dbo.Venues", new[] { "ApplicationUserCreatedById" });
            DropIndex("dbo.Venues", new[] { "CityId" });
            DropColumn("dbo.Venues", "ApplicationUserLastUpdatedDate");
            DropColumn("dbo.Venues", "ApplicationUserLastUpdatedById");
            DropColumn("dbo.Venues", "ApplicationUserCreatedDate");
            DropColumn("dbo.Venues", "ApplicationUserCreatedById");
            DropColumn("dbo.Venues", "CityId");
        }
    }
}
