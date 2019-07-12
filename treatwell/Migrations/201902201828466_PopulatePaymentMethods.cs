namespace treatwell.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulatePaymentMethods : DbMigration
    {
        public override void Up()
        {
            Sql("Insert into PaymentMethods Values('Pay at Venue')");
            Sql("Insert into PaymentMethods Values('Pay with Card')");
            Sql("Insert into PaymentMethods Values('Pay with Paypal')");
        }
        
        public override void Down()
        {
        }
    }
}
