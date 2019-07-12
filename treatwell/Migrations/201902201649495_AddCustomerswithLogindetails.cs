namespace treatwell.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCustomerswithLogindetails : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FullName = c.String(nullable: false),
                        Username = c.String(nullable: false),
                        Password = c.String(nullable: false),
                        Email = c.String(),
                        LogInDetailID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.LogInDetails", t => t.LogInDetailID, cascadeDelete: true)
                .Index(t => t.LogInDetailID);
            
            CreateTable(
                "dbo.LogInDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Website = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Customers", "LogInDetailID", "dbo.LogInDetails");
            DropIndex("dbo.Customers", new[] { "LogInDetailID" });
            DropTable("dbo.LogInDetails");
            DropTable("dbo.Customers");
        }
    }
}
