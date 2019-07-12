namespace treatwell.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateLogIndetails : DbMigration
    {
        public override void Up()
        {
            Sql("insert into LogInDetails Values('www.treatwell.com')");
            Sql("insert into LogInDetails Values('www.facebook.com')");
            Sql("insert into LogInDetails Values('www.twitter.com')");
            Sql("insert into LogInDetails Values('www.gmail.com')");
        }
        
        public override void Down()
        {
        }
    }
}
