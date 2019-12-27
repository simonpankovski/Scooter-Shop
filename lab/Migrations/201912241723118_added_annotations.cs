namespace lab.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class added_annotations : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Products", "Title", c => c.String(nullable: false, maxLength: 30));
            AlterColumn("dbo.Products", "Brand", c => c.String(nullable: false, maxLength: 20));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Products", "Brand", c => c.String());
            AlterColumn("dbo.Products", "Title", c => c.String());
        }
    }
}
