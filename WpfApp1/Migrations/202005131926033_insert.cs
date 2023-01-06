namespace WpfApp1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class insert : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Menus", "RestId", c => c.Int(nullable: false));
            DropColumn("dbo.Menus", "IdRest");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Menus", "IdRest", c => c.Int(nullable: false));
            DropColumn("dbo.Menus", "RestId");
        }
    }
}
