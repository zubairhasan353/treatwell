namespace treatwell.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlterTableCustomerReviewwithTime : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CustomerReviews", "ReviewTime", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.CustomerReviews", "ReviewTime");
        }
    }
}
