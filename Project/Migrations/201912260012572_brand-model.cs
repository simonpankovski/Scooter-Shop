namespace Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class brandmodel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Brands",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Products", "brandId", c => c.Int(nullable: false));
            CreateIndex("dbo.Products", "brandId");
            AddForeignKey("dbo.Products", "brandId", "dbo.Brands", "Id", cascadeDelete: true);
            DropColumn("dbo.Products", "Brand");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Products", "Brand", c => c.String(nullable: false, maxLength: 30));
            DropForeignKey("dbo.Products", "brandId", "dbo.Brands");
            DropIndex("dbo.Products", new[] { "brandId" });
            DropColumn("dbo.Products", "brandId");
            DropTable("dbo.Brands");
        }
    }
}
