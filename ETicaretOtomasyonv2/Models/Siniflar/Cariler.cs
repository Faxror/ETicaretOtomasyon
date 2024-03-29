﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ETicaretOtomasyonv2.Models.Siniflar
{
    public class Cariler
    {
        [Key]
        public int Cariid { get; set; }


        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string CariAd { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string CariSoyad { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(13)]
        public string CariSehir { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(50)]
        public string CariMail { get; set; }
        public string Kullaniciadi { get; set; }
        public string password { get; set; }
        public string passwordconfirim { get; set; }
        public string Rol { get; set; }

        public int SepetID { get; set; }

        public virtual Sepet Sepet { get; set; }
        public string CariUlke { get; set; }
        public bool Durum { get; set; }
        public ICollection<SatisHareket> SatisHareket { get; set; }
    }
}