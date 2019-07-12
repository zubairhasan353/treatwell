namespace treatwell.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateUserServicesandVenues : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.UserServices", new[] { "User_Id" });
            DropIndex("dbo.UserVenues", new[] { "User_Id" });
            DropColumn("dbo.UserServices", "UserId");
            DropColumn("dbo.UserVenues", "UserId");
            RenameColumn(table: "dbo.UserServices", name: "User_Id", newName: "UserId");
            RenameColumn(table: "dbo.UserVenues", name: "User_Id", newName: "UserId");
            AlterColumn("dbo.UserServices", "UserId", c => c.String(maxLength: 128));
            AlterColumn("dbo.UserVenues", "UserId", c => c.String(maxLength: 128));
            CreateIndex("dbo.UserServices", "UserId");
            CreateIndex("dbo.UserVenues", "UserId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.UserVenues", new[] { "UserId" });
            DropIndex("dbo.UserServices", new[] { "UserId" });
            AlterColumn("dbo.UserVenues", "UserId", c => c.Int(nullable: false));
            AlterColumn("dbo.UserServices", "UserId", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.UserVenues", name: "UserId", newName: "User_Id");
            RenameColumn(table: "dbo.UserServices", name: "UserId", newName: "User_Id");
            AddColumn("dbo.UserVenues", "UserId", c => c.Int(nullable: false));
            AddColumn("dbo.UserServices", "UserId", c => c.Int(nullable: false));
            CreateIndex("dbo.UserVenues", "User_Id");
            CreateIndex("dbo.UserServices", "User_Id");
        }
    }
}
