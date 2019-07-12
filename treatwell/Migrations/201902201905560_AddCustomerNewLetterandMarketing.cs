namespace treatwell.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCustomerNewLetterandMarketing : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CustomerNewLetterandMarketings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NewsLetterandMarketingId = c.Int(nullable: false),
                        EntryDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.NewsLetterandMarketings", t => t.NewsLetterandMarketingId, cascadeDelete: true)
                .Index(t => t.NewsLetterandMarketingId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CustomerNewLetterandMarketings", "NewsLetterandMarketingId", "dbo.NewsLetterandMarketings");
            DropIndex("dbo.CustomerNewLetterandMarketings", new[] { "NewsLetterandMarketingId" });
            DropTable("dbo.CustomerNewLetterandMarketings");
        }
    }
}
