namespace lab.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class added_annotations_1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "tags", c => c.String());
            AlterColumn("dbo.Products", "Brand", c => c.String(nullable: false, maxLength: 30));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Products", "Brand", c => c.String(nullable: false, maxLength: 20));
            DropColumn("dbo.Products", "tags");
        }
    }
}
