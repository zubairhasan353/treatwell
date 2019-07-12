namespace treatwell.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class alterEmployeeAbsent2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.EmployeeAbsents", "AbsentOn", c => c.DateTime(nullable: false));
            DropColumn("dbo.EmployeeAbsents", "AbsentOf");
        }
        
        public override void Down()
        {
            AddColumn("dbo.EmployeeAbsents", "AbsentOf", c => c.DateTime(nullable: false));
            DropColumn("dbo.EmployeeAbsents", "AbsentOn");
        }
    }
}
