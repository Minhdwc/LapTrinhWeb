namespace project_1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class YourMigrationName : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "Brands_BrandId", c => c.Int());
            AddColumn("dbo.Products", "Categories_CategoryId", c => c.Int());
            CreateIndex("dbo.Products", "Brands_BrandId");
            CreateIndex("dbo.Products", "Categories_CategoryId");
            AddForeignKey("dbo.Products", "Brands_BrandId", "dbo.Brands", "BrandId");
            AddForeignKey("dbo.Products", "Categories_CategoryId", "dbo.Categories", "CategoryId");
            DropColumn("dbo.Categories", "ProductId");
            DropColumn("dbo.Categories", "BrandId");
            DropColumn("dbo.Products", "CategoryId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Products", "CategoryId", c => c.Int(nullable: false));
            AddColumn("dbo.Categories", "BrandId", c => c.Int(nullable: false));
            AddColumn("dbo.Categories", "ProductId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Products", "Categories_CategoryId", "dbo.Categories");
            DropForeignKey("dbo.Products", "Brands_BrandId", "dbo.Brands");
            DropIndex("dbo.Products", new[] { "Categories_CategoryId" });
            DropIndex("dbo.Products", new[] { "Brands_BrandId" });
            DropColumn("dbo.Products", "Categories_CategoryId");
            DropColumn("dbo.Products", "Brands_BrandId");
        }
    }
}
