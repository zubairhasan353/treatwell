namespace treatwell.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addEmployeeAbsent : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.EmployeeAbsents",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EmployeeId = c.Int(nullable: false),
                        AbsentOf = c.DateTime(nullable: false),
                        ApplicationUserCreatedById = c.String(maxLength: 128),
                        ApplicationUserCreatedDate = c.DateTime(nullable: false),
                        ApplicationUserLastUpdatedById = c.String(maxLength: 128),
                        ApplicationUserLastUpdatedDate = c.DateTime(nullable: false),
                        Employee_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUserCreatedById)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUserLastUpdatedById)
                .ForeignKey("dbo.AspNetUsers", t => t.Employee_Id)
                .Index(t => t.ApplicationUserCreatedById)
                .Index(t => t.ApplicationUserLastUpdatedById)
                .Index(t => t.Employee_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.EmployeeAbsents", "Employee_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.EmployeeAbsents", "ApplicationUserLastUpdatedById", "dbo.AspNetUsers");
            DropForeignKey("dbo.EmployeeAbsents", "ApplicationUserCreatedById", "dbo.AspNetUsers");
            DropIndex("dbo.EmployeeAbsents", new[] { "Employee_Id" });
            DropIndex("dbo.EmployeeAbsents", new[] { "ApplicationUserLastUpdatedById" });
            DropIndex("dbo.EmployeeAbsents", new[] { "ApplicationUserCreatedById" });
            DropTable("dbo.EmployeeAbsents");
        }
    }
}
