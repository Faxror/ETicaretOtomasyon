using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ETicaretOtomasyonv2.Models.Siniflar
{
    public class Urunler
    {
        [Key]
        public int UrunID { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string UrunAd { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string Marka { get; set; }
        public short StokSayısı { get; set; }
        public decimal Fiyat { get; set; }
        public bool Durum { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(250)]
        public string UrunGorsel { get; set; }

        public int Kategoriid { get; set; }
        public  virtual Kategori Kategori { get; set; }

        public ICollection<SatisHareket> SatisHareket { get; set; }
    }
}