namespace treatwell.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlterNewsLetterandMarketing : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.NewsLetterandMarketings", "Heading", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.NewsLetterandMarketings", "Heading");
        }
    }
}
