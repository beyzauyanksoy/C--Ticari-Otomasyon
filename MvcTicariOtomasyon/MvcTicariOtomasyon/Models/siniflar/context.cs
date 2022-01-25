using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;


namespace MvcTicariOtomasyon.Models.siniflar
{
    public class context:DbContext
    {
        public DbSet<admin>admins{ get; set; }
        public DbSet<cariler>carilers{ get; set; }
        public DbSet<departman> departmans { get; set; }
        public DbSet<faturaKalem>faturaKalems{ get; set; }
        public DbSet<faturalar>faturalars{ get; set; }
        public DbSet<giderler>giderlers{ get; set; }
        public DbSet<kategori>kategoris{ get; set; }
        public DbSet<personel>personels{ get; set; }
        public DbSet<satisHareket>satisHarekets{ get; set; }
        public DbSet<urun>uruns{ get; set; }
        
        public DbSet<Detay> Detays { get; set; }
        public DbSet<Yapilacak> Yapilacaks { get; set; }
    }
}