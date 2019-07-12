namespace treatwell.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class alterDays0 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Days", "DayName", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Days", "DayName", c => c.String());
        }
    }
}
