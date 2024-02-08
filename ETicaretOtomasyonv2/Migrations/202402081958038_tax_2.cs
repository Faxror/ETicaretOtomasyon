namespace ETicaretOtomasyonv2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tax_2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Sepets", "Vergi", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Sepets", "Vergi");
        }
    }
}
