namespace WpfApp1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Restaurants",
                c => new
                    {
                        RestId = c.Int(nullable: false, identity: true),
                        RestName = c.String(),
                        RestSourse = c.String(),
                    })
                .PrimaryKey(t => t.RestId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Restaurants");
        }
    }
}
