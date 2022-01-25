using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcTicariOtomasyon.Models.siniflar;

namespace MvcTicariOtomasyon.Controllers
{
    public class CariController : Controller
    {
        // GET: Cari
        context c = new context();
        public ActionResult Index()
        {
            var degerler = c.carilers.Where(x=>x.Durum==true).ToList();

            return View(degerler);
        }
        [HttpGet]
        public ActionResult YeniCari()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniCari(cariler p)//tablodan bir parametre türetecek
        {
            p.Durum = true;
            c.carilers.Add(p);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult CariSil(int id)
        {
            var cr = c.carilers.Find(id);
            cr.Durum = false;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult CariGetir(int id)
        {
            var cari = c.carilers.Find(id);
            return View("CariGetir",cari);
        }
        public ActionResult CariGuncelle(cariler p)
        {
            if(!ModelState.IsValid)
            {
                return View("CariGetir");
            }
            var cari = c.carilers.Find(p.Cariid);
            cari.CariAd = p.CariAd;
            cari.CariSoyad = p.CariSoyad;
            cari.CariSehir = p.CariSehir;
            cari.CariMail = p.CariMail;
            c.SaveChanges();
            return RedirectToAction("Index");

        }
        public ActionResult MusteriSatis(int id)
        {
           
            var degerler = c.satisHarekets.Where(x => x.Cariid == id).ToList();
            var cr = c.carilers.Where(x => x.Cariid == id).Select(y => y.CariAd + " " + y.CariSoyad).FirstOrDefault();
            ViewBag.cari = cr;
            return View(degerler);

        }



    }
}