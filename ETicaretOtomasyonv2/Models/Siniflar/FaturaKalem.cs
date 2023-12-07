﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ETicaretOtomasyonv2.Models.Siniflar
{
    public class FaturaKalem
    {
        [Key]
        public int FaturaKalemID { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(100)]
        public string Açıklama { get; set; }
        public int Miktar { get; set; }
        public decimal BirtimFiyat { get; set; }
        public decimal Tutar { get; set; }

        public Faturalar Faturalar { get; set; }
    }
}