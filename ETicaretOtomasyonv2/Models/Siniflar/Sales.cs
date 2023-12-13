using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ETicaretOtomasyonv2.Models.Siniflar
{
    public class Sales
    {
        [Key]
        public int Id { get; set; }
        public int UrunId { get; set; }
        public virtual Urunler Urunler { get; set; }
        public decimal Adet { get; set; }
        public decimal Fiyat { get; set; }
        public DateTime Tarih { get; set; }
        public string Image { get; set; }
        public int UserId { get; set; }



    }
}