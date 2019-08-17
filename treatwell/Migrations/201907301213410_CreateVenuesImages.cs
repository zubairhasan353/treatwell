namespace treatwell.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateVenuesImages : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Venues", "ImagePath");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Venues", "ImagePath", c => c.String());
        }
    }
}
