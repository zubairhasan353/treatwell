namespace treatwell.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DropTableCitiesinVenues : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Venues", "CityId", "dbo.Cities");
            DropIndex("dbo.Venues", new[] { "CityId" });
            DropColumn("dbo.Venues", "CityId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Venues", "CityId", c => c.Int(nullable: false));
            CreateIndex("dbo.Venues", "CityId");
            AddForeignKey("dbo.Venues", "CityId", "dbo.Cities", "Id", cascadeDelete: true);
        }
    }
}
