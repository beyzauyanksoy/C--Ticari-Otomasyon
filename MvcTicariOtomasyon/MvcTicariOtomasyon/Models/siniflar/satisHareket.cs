using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcTicariOtomasyon.Models.siniflar
{
    public class satisHareket
    {
        [Key]
        public int Satisid { get; set; }
        //urun
        //cari
        //personel

        public DateTime Tarih { get; set; }
        public int Adet { get; set; }
        public decimal Fiyat { get; set; }
        public decimal ToplamTutar { get; set; }

        public int Urunid { get; set; }
        public int Cariid { get; set; }
        public int Personelid { get; set; }
        public virtual urun urun { get; set; }
        public virtual cariler cariler { get; set; }
        public virtual personel personel{ get; set; }
    }
}