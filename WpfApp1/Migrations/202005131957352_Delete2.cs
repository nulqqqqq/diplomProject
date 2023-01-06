namespace WpfApp1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Delete2 : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.Menus");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Menus",
                c => new
                    {
                        FoodId = c.Int(nullable: false, identity: true),
                        FoodName = c.String(),
                        FoodCount = c.Int(nullable: false),
                        RestId = c.Int(nullable: false),
                        Price = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.FoodId);
            
        }
    }
}
