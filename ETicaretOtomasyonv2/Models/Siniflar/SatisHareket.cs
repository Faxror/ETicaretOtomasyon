using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ETicaretOtomasyonv2.Models.Siniflar
{
    public class SatisHareket
    {
        [Key]
        public int SatisID { get; set; }
        public DateTime Tarih { get; set; }

        public int Adet { get; set; }
        public decimal Fiyat { get; set; }
        public decimal ToplamTutar { get; set; }

        public int UrunID { get; set; }
        public virtual Urunler Urun { get; set; }

        public int CariID { get; set; }
        public virtual Cariler Cariler { get; set; }

        public int PersonelID { get; set; }
        public virtual Personel Personel { get; set; }

        public int SepetID { get; set; }

        public virtual Sepet Sepet { get; set; }
    }
}