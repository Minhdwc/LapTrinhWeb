namespace project_1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addTotal : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Carts", "total", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Carts", "total");
        }
    }
}
