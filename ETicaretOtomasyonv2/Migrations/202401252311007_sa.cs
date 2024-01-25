namespace ETicaretOtomasyonv2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class sa : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Admins",
                c => new
                    {
                        AdminID = c.Int(nullable: false, identity: true),
                        KullaniciAd = c.String(maxLength: 10, unicode: false),
                        Sifre = c.String(maxLength: 10, unicode: false),
                        Yetki = c.String(maxLength: 10, fixedLength: true, unicode: false),
                    })
                .PrimaryKey(t => t.AdminID);
            
            CreateTable(
                "dbo.Carilers",
                c => new
                    {
                        Cariid = c.Int(nullable: false, identity: true),
                        CariAd = c.String(maxLength: 30, unicode: false),
                        CariSoyad = c.String(maxLength: 30, unicode: false),
                        CariSehir = c.String(maxLength: 13, unicode: false),
                        CariMail = c.String(maxLength: 50, unicode: false),
                        Kullaniciadi = c.String(),
                        password = c.String(),
                        passwordconfirim = c.String(),
                        Rol = c.String(),
                        SepetID = c.Int(nullable: false),
                        CariUlke = c.String(),
                        Durum = c.Boolean(nullable: false),
                        Sepet_Sepetıd = c.Int(),
                    })
                .PrimaryKey(t => t.Cariid)
                .ForeignKey("dbo.Sepets", t => t.Sepet_Sepetıd)
                .Index(t => t.Sepet_Sepetıd);
            
            CreateTable(
                "dbo.SatisHarekets",
                c => new
                    {
                        SatisID = c.Int(nullable: false, identity: true),
                        Tarih = c.DateTime(nullable: false),
                        Adet = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Fiyat = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ToplamTutar = c.Decimal(nullable: false, precision: 18, scale: 2),
                        UrunID = c.Int(nullable: false),
                        CariID = c.Int(nullable: false),
                        SepetID = c.Int(nullable: false),
                        Sepet_Sepetıd = c.Int(),
                        Personel_PersonelID = c.Int(),
                    })
                .PrimaryKey(t => t.SatisID)
                .ForeignKey("dbo.Carilers", t => t.CariID, cascadeDelete: true)
                .ForeignKey("dbo.Sepets", t => t.Sepet_Sepetıd)
                .ForeignKey("dbo.Urunlers", t => t.UrunID, cascadeDelete: true)
                .ForeignKey("dbo.Personels", t => t.Personel_PersonelID)
                .Index(t => t.UrunID)
                .Index(t => t.CariID)
                .Index(t => t.Sepet_Sepetıd)
                .Index(t => t.Personel_PersonelID);
            
            CreateTable(
                "dbo.Sepets",
                c => new
                    {
                        Sepetıd = c.Int(nullable: false, identity: true),
                        UrunId = c.Int(nullable: false),
                        Adet = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Fiyat = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Tarih = c.DateTime(nullable: false),
                        kullaniciid = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Sepetıd)
                .ForeignKey("dbo.Urunlers", t => t.UrunId, cascadeDelete: true)
                .Index(t => t.UrunId);
            
            CreateTable(
                "dbo.Urunlers",
                c => new
                    {
                        UrunID = c.Int(nullable: false, identity: true),
                        UrunAd = c.String(maxLength: 30, unicode: false),
                        Marka = c.String(maxLength: 30, unicode: false),
                        StokSayısı = c.Short(nullable: false),
                        Fiyat = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Durum = c.Boolean(nullable: false),
                        UrunGorsel = c.String(maxLength: 250, unicode: false),
                        Kategoriid = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.UrunID)
                .ForeignKey("dbo.Kategoris", t => t.Kategoriid, cascadeDelete: true)
                .Index(t => t.Kategoriid);
            
            CreateTable(
                "dbo.Kategoris",
                c => new
                    {
                        KategoriID = c.Int(nullable: false, identity: true),
                        KategoriAd = c.String(maxLength: 30, unicode: false),
                    })
                .PrimaryKey(t => t.KategoriID);
            
            CreateTable(
                "dbo.Departmen",
                c => new
                    {
                        DepartmanID = c.Int(nullable: false, identity: true),
                        DepartmanAdı = c.String(maxLength: 30, unicode: false),
                        Durum = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.DepartmanID);
            
            CreateTable(
                "dbo.Personels",
                c => new
                    {
                        PersonelID = c.Int(nullable: false, identity: true),
                        PersonelAd = c.String(maxLength: 30, unicode: false),
                        PersonelSoyad = c.String(maxLength: 30, unicode: false),
                        PersonelGorsel = c.String(maxLength: 250, unicode: false),
                        DepartmanID = c.Int(nullable: false),
                        Durum = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.PersonelID)
                .ForeignKey("dbo.Departmen", t => t.DepartmanID, cascadeDelete: true)
                .Index(t => t.DepartmanID);
            
            CreateTable(
                "dbo.FaturaKalems",
                c => new
                    {
                        FaturaKalemID = c.Int(nullable: false, identity: true),
                        Açıklama = c.String(maxLength: 100, unicode: false),
                        Miktar = c.Int(nullable: false),
                        BirtimFiyat = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Tutar = c.Decimal(nullable: false, precision: 18, scale: 2),
                        FaturaID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.FaturaKalemID)
                .ForeignKey("dbo.Faturalars", t => t.FaturaID, cascadeDelete: true)
                .Index(t => t.FaturaID);
            
            CreateTable(
                "dbo.Faturalars",
                c => new
                    {
                        FaturaID = c.Int(nullable: false, identity: true),
                        FaturaSerino = c.String(maxLength: 1, unicode: false),
                        FaturaSırano = c.String(maxLength: 6, unicode: false),
                        Tarihi = c.DateTime(nullable: false),
                        VergiDairesi = c.String(maxLength: 60, unicode: false),
                        Saat = c.String(maxLength: 5, fixedLength: true, unicode: false),
                        TeslimEden = c.String(maxLength: 30, unicode: false),
                        TeslimAlan = c.String(maxLength: 30, unicode: false),
                        Toplam = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.FaturaID);
            
            CreateTable(
                "dbo.Giders",
                c => new
                    {
                        GiderID = c.Int(nullable: false, identity: true),
                        Aciklama = c.String(maxLength: 100, unicode: false),
                        Tarih = c.DateTime(nullable: false),
                        Tutar = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.GiderID);
            
            CreateTable(
                "dbo.Sales",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UrunId = c.Int(nullable: false),
                        Adet = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Fiyat = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Tarih = c.DateTime(nullable: false),
                        Image = c.String(),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Urunlers", t => t.UrunId, cascadeDelete: true)
                .Index(t => t.UrunId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Sales", "UrunId", "dbo.Urunlers");
            DropForeignKey("dbo.FaturaKalems", "FaturaID", "dbo.Faturalars");
            DropForeignKey("dbo.SatisHarekets", "Personel_PersonelID", "dbo.Personels");
            DropForeignKey("dbo.Personels", "DepartmanID", "dbo.Departmen");
            DropForeignKey("dbo.Sepets", "UrunId", "dbo.Urunlers");
            DropForeignKey("dbo.SatisHarekets", "UrunID", "dbo.Urunlers");
            DropForeignKey("dbo.Urunlers", "Kategoriid", "dbo.Kategoris");
            DropForeignKey("dbo.SatisHarekets", "Sepet_Sepetıd", "dbo.Sepets");
            DropForeignKey("dbo.Carilers", "Sepet_Sepetıd", "dbo.Sepets");
            DropForeignKey("dbo.SatisHarekets", "CariID", "dbo.Carilers");
            DropIndex("dbo.Sales", new[] { "UrunId" });
            DropIndex("dbo.FaturaKalems", new[] { "FaturaID" });
            DropIndex("dbo.Personels", new[] { "DepartmanID" });
            DropIndex("dbo.Urunlers", new[] { "Kategoriid" });
            DropIndex("dbo.Sepets", new[] { "UrunId" });
            DropIndex("dbo.SatisHarekets", new[] { "Personel_PersonelID" });
            DropIndex("dbo.SatisHarekets", new[] { "Sepet_Sepetıd" });
            DropIndex("dbo.SatisHarekets", new[] { "CariID" });
            DropIndex("dbo.SatisHarekets", new[] { "UrunID" });
            DropIndex("dbo.Carilers", new[] { "Sepet_Sepetıd" });
            DropTable("dbo.Sales");
            DropTable("dbo.Giders");
            DropTable("dbo.Faturalars");
            DropTable("dbo.FaturaKalems");
            DropTable("dbo.Personels");
            DropTable("dbo.Departmen");
            DropTable("dbo.Kategoris");
            DropTable("dbo.Urunlers");
            DropTable("dbo.Sepets");
            DropTable("dbo.SatisHarekets");
            DropTable("dbo.Carilers");
            DropTable("dbo.Admins");
        }
    }
}
