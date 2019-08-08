namespace treatwell.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlterDelCustomerReviewTime : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.CustomerReviews", "ReviewTime");
        }
        
        public override void Down()
        {
            AddColumn("dbo.CustomerReviews", "ReviewTime", c => c.DateTime(nullable: false));
        }
    }
}
