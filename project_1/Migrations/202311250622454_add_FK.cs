namespace project_1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_FK : DbMigration
    {
        public override void Up()
        {
            AddForeignKey("Products", "CategoryID", "Categories");
        }
        
        public override void Down()
        {
        }
    }
}
