namespace treatwell.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateNewsLetterandMarketing1 : DbMigration
    {
        public override void Up()
        {
            Sql("Insert Into NewsLetterandMarketings Values('Tick this box if you don’t want to receive emails from Treatwell with the latest offers & beauty news.', 'TREATWELL NEWSLETTER')");
            Sql("Insert Into NewsLetterandMarketings Values('Tick to allow the venue I’m booking with to send me emails and SMS about their services.', 'SALON MARKETING')");
        }
        
        public override void Down()
        {
        }
    }
}
