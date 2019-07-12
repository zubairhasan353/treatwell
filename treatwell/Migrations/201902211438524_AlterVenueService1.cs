namespace treatwell.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlterVenueService1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.VenueServices", "DiscountedPercentage", c => c.Int(nullable: false));
            DropColumn("dbo.VenueServices", "DiscountedCostPrice");
        }
        
        public override void Down()
        {
            AddColumn("dbo.VenueServices", "DiscountedCostPrice", c => c.Int(nullable: false));
            DropColumn("dbo.VenueServices", "DiscountedPercentage");
        }
    }
}
