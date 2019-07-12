namespace treatwell.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUserServices : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserServices",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        subCategoriesId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                        ApplicationUserCreatedById = c.String(maxLength: 128),
                        ApplicationUserCreatedDate = c.DateTime(nullable: false),
                        ApplicationUserLastUpdatedById = c.String(maxLength: 128),
                        ApplicationUserLastUpdatedDate = c.DateTime(nullable: false),
                        User_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUserCreatedById)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUserLastUpdatedById)
                .ForeignKey("dbo.SubCategories", t => t.subCategoriesId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id)
                .Index(t => t.subCategoriesId)
                .Index(t => t.ApplicationUserCreatedById)
                .Index(t => t.ApplicationUserLastUpdatedById)
                .Index(t => t.User_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserServices", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.UserServices", "subCategoriesId", "dbo.SubCategories");
            DropForeignKey("dbo.UserServices", "ApplicationUserLastUpdatedById", "dbo.AspNetUsers");
            DropForeignKey("dbo.UserServices", "ApplicationUserCreatedById", "dbo.AspNetUsers");
            DropIndex("dbo.UserServices", new[] { "User_Id" });
            DropIndex("dbo.UserServices", new[] { "ApplicationUserLastUpdatedById" });
            DropIndex("dbo.UserServices", new[] { "ApplicationUserCreatedById" });
            DropIndex("dbo.UserServices", new[] { "subCategoriesId" });
            DropTable("dbo.UserServices");
        }
    }
}
