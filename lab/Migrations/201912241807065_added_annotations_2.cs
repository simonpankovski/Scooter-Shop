namespace lab.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class added_annotations_2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Products", "Title", c => c.String(nullable: false, maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Products", "Title", c => c.String(nullable: false, maxLength: 30));
        }
    }
}
