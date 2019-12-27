namespace lab.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update_db : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Url = c.String(),
                        Price = c.Int(nullable: false),
                        Description = c.String(),
                        Brand = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
           
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.FriendModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Ime = c.String(),
                        MestoNaZiveenje = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            DropTable("dbo.Products");
        }
    }
}
