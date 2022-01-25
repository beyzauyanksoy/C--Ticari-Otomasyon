using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcTicariOtomasyon.Models.siniflar;
namespace MvcTicariOtomasyon.Controllers
{
    public class İstatistikController : Controller
    {
        // GET: İstatistik
        context c = new context();
        public ActionResult Index()
        {
            var deger1 = c.carilers.Count().ToString();
            ViewBag.d1 = deger1;
            var deger2 = c.uruns.Count().ToString();
            ViewBag.d2 = deger2; 
            var deger3 = c.personels.Count().ToString();
            ViewBag.d3 = deger3;
            var deger4 = c.kategoris.Count().ToString();
            ViewBag.d4 = deger4;
            var deger5 = c.uruns.Sum(x => x.Stok).ToString();
            ViewBag.d5 = deger5;
            var deger6 = (from x in c.uruns orderby x.SatisFiyat ascending select x.UrunAd).FirstOrDefault();
            ViewBag.d6 = deger6;

            var deger7 = c.uruns.Count(x => x.Stok <= 5).ToString();
            ViewBag.d7 = deger7;
            var deger8 = (from x in c.uruns orderby x.SatisFiyat descending select x.UrunAd).FirstOrDefault();
            ViewBag.d8 = deger8;

            var deger13 = from SatisHareket in c.satisHarekets

                          join Urun in c.uruns on SatisHareket.Urunid equals Urun.Urunid

                          group SatisHareket by SatisHareket.urun.UrunAd into grup

                          select new

                          {

                              UrunAd = grup.Key,

                              Adet = grup.Sum(x => x.Adet)

                          };

            ViewBag.d13 = deger13.OrderByDescending(x => x.Adet).ToList().FirstOrDefault().UrunAd;
            var deger14 = c.satisHarekets.Sum(x => x.ToplamTutar).ToString();
            ViewBag.d14 = deger14;
            DateTime bugun = DateTime.Today;
            var deger15 = c.satisHarekets.Count(x => x.Tarih == bugun).ToString();
            ViewBag.d15 = deger15;
            var deger16 = c.satisHarekets.Where(x => x.Tarih == bugun).Sum(y => y.ToplamTutar).ToString();
            ViewBag.d16 = deger16;
            return View();


            
        }
        public ActionResult KolayTablolar()
        {
            var sorgu = from x in c.carilers
                        group x by x.CariSehir into g
                        select new SinifGrup
                        {
                            Sehir = g.Key,
                            Sayi = g.Count()

                        };
            return View(sorgu.ToList());
        }
        public PartialViewResult Partial1()
        {
            return PartialView();
        }
    }
}