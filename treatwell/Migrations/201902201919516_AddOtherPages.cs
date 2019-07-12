namespace treatwell.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddOtherPages : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.OtherPages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PageName = c.String(nullable: false),
                        ImagePath = c.String(),
                        PageDesc = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.OtherPages");
        }
    }
}
