using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcTicariOtomasyon.Models.siniflar
{
    public class personel
    {
        [Key]
        public int Personelid { get; set; }

        [Display(Name ="Personel Adı")]
        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string PersonelAd { get; set; }

        [Display(Name ="Personel Soyadı")]
        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string PersonelSoyad { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(250)]

        [Display(Name = "Personel Görseli")]
        public string PersonelGorsel { get; set; }
        public ICollection<satisHareket> SatisHarekets { get; set; }
        public int Departmanid { get; set; }
        public virtual departman Departman { get; set; }

    }
}