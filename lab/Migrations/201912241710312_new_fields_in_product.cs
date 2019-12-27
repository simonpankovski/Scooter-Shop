namespace lab.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class new_fields_in_product : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "stock", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Products", "stock");
        }
    }
}
