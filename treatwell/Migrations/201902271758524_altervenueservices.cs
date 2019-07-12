namespace treatwell.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class altervenueservices : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.VenueServices", new[] { "VenuesID" });
            CreateIndex("dbo.VenueServices", "VenuesId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.VenueServices", new[] { "VenuesId" });
            CreateIndex("dbo.VenueServices", "VenuesID");
        }
    }
}
