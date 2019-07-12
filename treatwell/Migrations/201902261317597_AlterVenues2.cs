namespace treatwell.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlterVenues2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Venues", "ImagePath", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Venues", "ImagePath", c => c.String(nullable: false));
        }
    }
}
