namespace WpfApp1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRest1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Restaurants", "RestSourse", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Restaurants", "RestSourse");
        }
    }
}
