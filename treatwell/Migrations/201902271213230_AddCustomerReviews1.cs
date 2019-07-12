namespace treatwell.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCustomerReviews1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CustomerReviews",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CustomerBookingId = c.Int(nullable: false),
                        Experience = c.String(),
                        Ambience = c.Int(nullable: false),
                        Staff = c.Int(nullable: false),
                        Cleanliness = c.Int(nullable: false),
                        Value = c.Int(nullable: false),
                        ReviewDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CustomerBookings", t => t.CustomerBookingId, cascadeDelete: true)
                .Index(t => t.CustomerBookingId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CustomerReviews", "CustomerBookingId", "dbo.CustomerBookings");
            DropIndex("dbo.CustomerReviews", new[] { "CustomerBookingId" });
            DropTable("dbo.CustomerReviews");
        }
    }
}
