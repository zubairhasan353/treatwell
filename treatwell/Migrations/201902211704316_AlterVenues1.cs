namespace treatwell.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlterVenues1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Venues", "Street", c => c.String());
            AddColumn("dbo.Venues", "Sector", c => c.String());
            DropColumn("dbo.Venues", "Username");
            DropColumn("dbo.Venues", "Password");
            DropColumn("dbo.Venues", "Email");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Venues", "Email", c => c.String(nullable: false));
            AddColumn("dbo.Venues", "Password", c => c.String(nullable: false));
            AddColumn("dbo.Venues", "Username", c => c.String(nullable: false));
            DropColumn("dbo.Venues", "Sector");
            DropColumn("dbo.Venues", "Street");
        }
    }
}
