namespace project_1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updbNew : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("Products", "FK_dbo.Products_dbo.Categories_Categories_CategoryId");
            RenameColumn(table: "dbo.Products", name: "Categories_CategoryId", newName: "CategoryID");
            RenameIndex(table: "dbo.Products", name: "IX_Categories_CategoryId", newName: "IX_CategoryID");
            DropColumn("dbo.Products", "CateID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Products", "CateID", c => c.Int());
            RenameIndex(table: "dbo.Products", name: "IX_CategoryID", newName: "IX_Categories_CategoryId");
            RenameColumn(table: "dbo.Products", name: "CategoryID", newName: "Categories_CategoryId");
        }
    }
}
