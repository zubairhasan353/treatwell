namespace treatwell.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPaymentMethods : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PaymentMethods",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Desc = c.String(),
                        ApplicationUserCreatedById = c.String(maxLength: 128),
                        ApplicationUserCreatedDate = c.DateTime(nullable: false),
                        ApplicationUserLastUpdatedById = c.String(maxLength: 128),
                        ApplicationUserLastUpdatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUserCreatedById)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUserLastUpdatedById)
                .Index(t => t.ApplicationUserCreatedById)
                .Index(t => t.ApplicationUserLastUpdatedById);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PaymentMethods", "ApplicationUserLastUpdatedById", "dbo.AspNetUsers");
            DropForeignKey("dbo.PaymentMethods", "ApplicationUserCreatedById", "dbo.AspNetUsers");
            DropIndex("dbo.PaymentMethods", new[] { "ApplicationUserLastUpdatedById" });
            DropIndex("dbo.PaymentMethods", new[] { "ApplicationUserCreatedById" });
            DropTable("dbo.PaymentMethods");
        }
    }
}
