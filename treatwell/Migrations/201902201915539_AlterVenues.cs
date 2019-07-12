namespace treatwell.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlterVenues : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Venues", "CityId", c => c.Int(nullable: false));
            CreateIndex("dbo.Venues", "CityId");
            AddForeignKey("dbo.Venues", "CityId", "dbo.Cities", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Venues", "CityId", "dbo.Cities");
            DropIndex("dbo.Venues", new[] { "CityId" });
            DropColumn("dbo.Venues", "CityId");
        }
    }
}
