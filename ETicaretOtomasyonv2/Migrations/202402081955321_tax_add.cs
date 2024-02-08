namespace ETicaretOtomasyonv2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tax_add : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Urunlers", "Vergi", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Urunlers", "Vergi");
        }
    }
}
