namespace treatwell.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlterCities : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Cities", "PostalCode", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Cities", "PostalCode");
        }
    }
}
