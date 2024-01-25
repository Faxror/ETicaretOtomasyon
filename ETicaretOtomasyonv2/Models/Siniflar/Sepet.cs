using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ETicaretOtomasyonv2.Models.Siniflar
{
    public class Sepet
    {
        [Key]
        public int Sepetıd { get; set; }

        public int UrunId { get; set; }

        public decimal Adet { get; set; }
        public decimal Fiyat { get; set; }
        public DateTime Tarih { get; set; }
        public int kullaniciid { get; set; }

        // Sepetin birden fazla satış hareketini içerdiğini varsayarsak:
        public ICollection<SatisHareket> SatisHareketleri { get; set; }

        // Sepetin birden fazla müşteriyi içerdiğini varsayarsak:
        public ICollection<Cariler> Cariler { get; set; }
        public virtual Urunler Urunler { get; set; }


    }
}