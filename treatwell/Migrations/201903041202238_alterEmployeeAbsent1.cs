namespace treatwell.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class alterEmployeeAbsent1 : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.EmployeeAbsents", new[] { "Employee_Id" });
            DropColumn("dbo.EmployeeAbsents", "EmployeeId");
            RenameColumn(table: "dbo.EmployeeAbsents", name: "Employee_Id", newName: "EmployeeId");
            AlterColumn("dbo.EmployeeAbsents", "EmployeeId", c => c.String(maxLength: 128));
            CreateIndex("dbo.EmployeeAbsents", "EmployeeId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.EmployeeAbsents", new[] { "EmployeeId" });
            AlterColumn("dbo.EmployeeAbsents", "EmployeeId", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.EmployeeAbsents", name: "EmployeeId", newName: "Employee_Id");
            AddColumn("dbo.EmployeeAbsents", "EmployeeId", c => c.Int(nullable: false));
            CreateIndex("dbo.EmployeeAbsents", "Employee_Id");
        }
    }
}
