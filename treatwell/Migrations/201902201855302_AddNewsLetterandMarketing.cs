namespace treatwell.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddNewsLetterandMarketing : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.NewsLetterandMarketings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Desc = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.NewsLetterandMarketings");
        }
    }
}
