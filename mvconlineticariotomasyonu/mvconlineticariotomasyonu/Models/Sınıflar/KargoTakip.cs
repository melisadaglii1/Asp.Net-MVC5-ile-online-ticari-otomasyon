﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace mvconlineotomasyon.Models.sınıflar
{
    public class KargoTakip
    {
        [Key]
        public int KargoTakipid { get; set; }

        [Column(TypeName = "varchar")]
        [StringLength(10)]
        public string TakipKodu { get; set; }

        [Column(TypeName = "varchar")]
        [StringLength(100)]
        public string Aciklama { get; set; }
        public DateTime TarihZaman { get; set; }
    }
}