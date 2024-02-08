namespace ETicaretOtomasyonv2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tax_3 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Sepets", "Vergi", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Urunlers", "Vergi", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Urunlers", "Vergi", c => c.Int(nullable: false));
            AlterColumn("dbo.Sepets", "Vergi", c => c.Int(nullable: false));
        }
    }
}
