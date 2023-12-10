namespace project_1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpSize : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Products", "ProductSize", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Products", "ProductSize", c => c.Int(nullable: false));
        }
    }
}
