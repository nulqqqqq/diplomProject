namespace WpfApp1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Delete1 : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.Restaurants");
        }
        
        public override void Down()
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
    }
}
