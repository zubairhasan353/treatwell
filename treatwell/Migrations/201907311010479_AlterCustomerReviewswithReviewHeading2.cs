namespace treatwell.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlterCustomerReviewswithReviewHeading2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CustomerReviews", "ExperienceHeading", c => c.String());
            AddColumn("dbo.CustomerReviews", "ExperienceRemarks", c => c.String());
            DropColumn("dbo.CustomerReviews", "Experience");
            DropColumn("dbo.CustomerReviews", "RemarksHeading");
            DropColumn("dbo.CustomerReviews", "CustomerRemarks");
        }
        
        public override void Down()
        {
            AddColumn("dbo.CustomerReviews", "CustomerRemarks", c => c.String());
            AddColumn("dbo.CustomerReviews", "RemarksHeading", c => c.String());
            AddColumn("dbo.CustomerReviews", "Experience", c => c.String());
            DropColumn("dbo.CustomerReviews", "ExperienceRemarks");
            DropColumn("dbo.CustomerReviews", "ExperienceHeading");
        }
    }
}
