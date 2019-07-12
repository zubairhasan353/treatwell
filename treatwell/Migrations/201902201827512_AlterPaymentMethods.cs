namespace treatwell.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlterPaymentMethods : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.PaymentMethods", "ApplicationUserCreatedById", "dbo.AspNetUsers");
            DropForeignKey("dbo.PaymentMethods", "ApplicationUserLastUpdatedById", "dbo.AspNetUsers");
            DropIndex("dbo.PaymentMethods", new[] { "ApplicationUserCreatedById" });
            DropIndex("dbo.PaymentMethods", new[] { "ApplicationUserLastUpdatedById" });
            DropColumn("dbo.PaymentMethods", "ApplicationUserCreatedById");
            DropColumn("dbo.PaymentMethods", "ApplicationUserCreatedDate");
            DropColumn("dbo.PaymentMethods", "ApplicationUserLastUpdatedById");
            DropColumn("dbo.PaymentMethods", "ApplicationUserLastUpdatedDate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.PaymentMethods", "ApplicationUserLastUpdatedDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.PaymentMethods", "ApplicationUserLastUpdatedById", c => c.String(maxLength: 128));
            AddColumn("dbo.PaymentMethods", "ApplicationUserCreatedDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.PaymentMethods", "ApplicationUserCreatedById", c => c.String(maxLength: 128));
            CreateIndex("dbo.PaymentMethods", "ApplicationUserLastUpdatedById");
            CreateIndex("dbo.PaymentMethods", "ApplicationUserCreatedById");
            AddForeignKey("dbo.PaymentMethods", "ApplicationUserLastUpdatedById", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.PaymentMethods", "ApplicationUserCreatedById", "dbo.AspNetUsers", "Id");
        }
    }
}
