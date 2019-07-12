namespace treatwell.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateProductsandProdsinSubCat : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ProdsUsedInSubCats",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProductId = c.Int(nullable: false),
                        SubCatId = c.Int(nullable: false),
                        QtyUsed = c.Int(nullable: false),
                        ApplicationUserCreatedById = c.String(maxLength: 128),
                        ApplicationUserCreatedDate = c.DateTime(nullable: false),
                        ApplicationUserLastUpdatedById = c.String(maxLength: 128),
                        ApplicationUserLastUpdatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUserCreatedById)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUserLastUpdatedById)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .ForeignKey("dbo.SubCategories", t => t.SubCatId, cascadeDelete: true)
                .Index(t => t.ProductId)
                .Index(t => t.SubCatId)
                .Index(t => t.ApplicationUserCreatedById)
                .Index(t => t.ApplicationUserLastUpdatedById);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProductName = c.String(),
                        Ingrediants = c.String(),
                        ApplicationUserCreatedById = c.String(maxLength: 128),
                        ApplicationUserCreatedDate = c.DateTime(nullable: false),
                        ApplicationUserLastUpdatedById = c.String(maxLength: 128),
                        ApplicationUserLastUpdatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUserCreatedById)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUserLastUpdatedById)
                .Index(t => t.ApplicationUserCreatedById)
                .Index(t => t.ApplicationUserLastUpdatedById);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProdsUsedInSubCats", "SubCatId", "dbo.SubCategories");
            DropForeignKey("dbo.ProdsUsedInSubCats", "ProductId", "dbo.Products");
            DropForeignKey("dbo.Products", "ApplicationUserLastUpdatedById", "dbo.AspNetUsers");
            DropForeignKey("dbo.Products", "ApplicationUserCreatedById", "dbo.AspNetUsers");
            DropForeignKey("dbo.ProdsUsedInSubCats", "ApplicationUserLastUpdatedById", "dbo.AspNetUsers");
            DropForeignKey("dbo.ProdsUsedInSubCats", "ApplicationUserCreatedById", "dbo.AspNetUsers");
            DropIndex("dbo.Products", new[] { "ApplicationUserLastUpdatedById" });
            DropIndex("dbo.Products", new[] { "ApplicationUserCreatedById" });
            DropIndex("dbo.ProdsUsedInSubCats", new[] { "ApplicationUserLastUpdatedById" });
            DropIndex("dbo.ProdsUsedInSubCats", new[] { "ApplicationUserCreatedById" });
            DropIndex("dbo.ProdsUsedInSubCats", new[] { "SubCatId" });
            DropIndex("dbo.ProdsUsedInSubCats", new[] { "ProductId" });
            DropTable("dbo.Products");
            DropTable("dbo.ProdsUsedInSubCats");
        }
    }
}
