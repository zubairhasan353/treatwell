namespace treatwell.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateDays : DbMigration
    {
        public override void Up()
        {
            Sql("Insert into Days Values('Monday')");
            Sql("Insert into Days Values('Tuesday')");
            Sql("Insert into Days Values('Wednesday')");
            Sql("Insert into Days Values('Thursday')");
            Sql("Insert into Days Values('Friday')");
            Sql("Insert into Days Values('Saturday')");
            Sql("Insert into Days Values('Sunday')");
        }
        
        public override void Down()
        {
        }
    }
}
