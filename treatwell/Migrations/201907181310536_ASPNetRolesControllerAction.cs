namespace treatwell.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ASPNetRolesControllerAction : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AspNetRolesControllerActions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ActionName = c.String(),
                        ActionDesc = c.String(),
                        AspNetRolesControllerId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetRolesControllers", t => t.AspNetRolesControllerId)
                .Index(t => t.AspNetRolesControllerId);
            
            CreateTable(
                "dbo.AspNetRolesControllers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ControllerName = c.String(),
                        ControllerDesc = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetRolesControllerActions", "AspNetRolesControllerId", "dbo.AspNetRolesControllers");
            DropIndex("dbo.AspNetRolesControllerActions", new[] { "AspNetRolesControllerId" });
            DropTable("dbo.AspNetRolesControllers");
            DropTable("dbo.AspNetRolesControllerActions");
        }
    }
}
