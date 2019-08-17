namespace treatwell.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlterCustomerReviewswithReviewHeading1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CustomerReviews", "RemarksHeading", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.CustomerReviews", "RemarksHeading");
        }
    }
}
