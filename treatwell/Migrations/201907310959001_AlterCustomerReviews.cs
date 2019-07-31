namespace treatwell.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlterCustomerReviews : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CustomerReviews", "CustomerRemarks", c => c.String());
            AlterColumn("dbo.CustomerReviews", "Ambience", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.CustomerReviews", "Staff", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.CustomerReviews", "Cleanliness", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.CustomerReviews", "Value", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.CustomerReviews", "Value", c => c.Int(nullable: false));
            AlterColumn("dbo.CustomerReviews", "Cleanliness", c => c.Int(nullable: false));
            AlterColumn("dbo.CustomerReviews", "Staff", c => c.Int(nullable: false));
            AlterColumn("dbo.CustomerReviews", "Ambience", c => c.Int(nullable: false));
            DropColumn("dbo.CustomerReviews", "CustomerRemarks");
        }
    }
}
