namespace treatwell.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DelUserandRolesControllerAction : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AspNetRolesControllerActions", "AspNetRolesControllerId", "dbo.AspNetRolesControllers");
            DropIndex("dbo.AspNetRolesControllerActions", new[] { "AspNetRolesControllerId" });
            AddColumn("dbo.AspNetRoles", "Discriminator", c => c.String(nullable: false, maxLength: 128));
            DropTable("dbo.AspNetRolesControllerActions");
            DropTable("dbo.AspNetRolesControllers");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.AspNetRolesControllers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ControllerName = c.String(),
                        ControllerDesc = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AspNetRolesControllerActions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ActionName = c.String(),
                        ActionDesc = c.String(),
                        AspNetRolesControllerId = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            DropColumn("dbo.AspNetRoles", "Discriminator");
            CreateIndex("dbo.AspNetRolesControllerActions", "AspNetRolesControllerId");
            AddForeignKey("dbo.AspNetRolesControllerActions", "AspNetRolesControllerId", "dbo.AspNetRolesControllers", "Id");
        }
    }
}
