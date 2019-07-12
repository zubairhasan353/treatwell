namespace treatwell.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeleteCustomer : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Customers", "LogInDetailID", "dbo.LogInDetails");
            DropIndex("dbo.Customers", new[] { "LogInDetailID" });
            DropTable("dbo.Customers");
        }
        
        public override void Down()
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
                .PrimaryKey(t => t.Id);
            
            CreateIndex("dbo.Customers", "LogInDetailID");
            AddForeignKey("dbo.Customers", "LogInDetailID", "dbo.LogInDetails", "Id", cascadeDelete: true);
        }
    }
}
