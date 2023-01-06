namespace WpfApp1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddOrders : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        IdOrder = c.Int(nullable: false, identity: true),
                        IdUser = c.Int(nullable: false),
                        IdFood = c.Int(nullable: false),
                        Adress = c.String(),
                    })
                .PrimaryKey(t => t.IdOrder);
            
            AddColumn("dbo.Menus", "IdRest", c => c.Int(nullable: false));
            AddColumn("dbo.Menus", "Price", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Menus", "Price");
            DropColumn("dbo.Menus", "IdRest");
            DropTable("dbo.Orders");
        }
    }
}
