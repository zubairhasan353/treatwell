namespace treatwell.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlterVenueService : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.VenueServices", "ActualCostPrice", c => c.Int(nullable: false));
            AddColumn("dbo.VenueServices", "DiscountedCostPrice", c => c.Int(nullable: false));
            DropColumn("dbo.VenueServices", "CostPrice");
        }
        
        public override void Down()
        {
            AddColumn("dbo.VenueServices", "CostPrice", c => c.Int(nullable: false));
            DropColumn("dbo.VenueServices", "DiscountedCostPrice");
            DropColumn("dbo.VenueServices", "ActualCostPrice");
        }
    }
}
