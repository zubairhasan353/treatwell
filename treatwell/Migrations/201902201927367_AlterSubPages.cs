namespace treatwell.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlterSubPages : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.SubPages", new[] { "OtherPageid" });
            CreateIndex("dbo.SubPages", "OtherPageId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.SubPages", new[] { "OtherPageId" });
            CreateIndex("dbo.SubPages", "OtherPageid");
        }
    }
}
