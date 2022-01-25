using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcTicariOtomasyon.Models.siniflar;//sınıflara erişmek için
namespace MvcTicariOtomasyon.Controllers
{
    public class KategoriController : Controller
    {
        // GET: Kategori
        context c = new context();//sınıfların içerinsindeki context adlı sınıfıdan bir nesne üreticez(tablolar context içinde)

        public ActionResult Index()
        {
            var degerler = c.kategoris.ToList();

            return View(degerler);//geriye degerler döndürülecek.
        }

        [HttpGet]
        public ActionResult KategoriEkle()
        {
            return View();//burası sadece boş bir sayfa getirecek
        }
        [HttpPost]
        public ActionResult KategoriEkle(kategori k) //butona tıkladıgımız zaman burası çalışacak.
        {
            c.kategoris.Add(k);//k dan gelen degeri contex in içinde bulunan kategoris e ekler
            c.SaveChanges();//degişikleri kaydet
            return RedirectToAction("Index");  //bu işlem bittiginde bizi bir aksiyona yönlendirir.
            
            
        }
        public ActionResult KategoriSil(int id)
        {
            var ktg = c.kategoris.Find(id);
            c.kategoris.Remove(ktg);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult KategoriGetir(int id)
        {
            var kategori = c.kategoris.Find(id);
            return View("KategoriGetir", kategori);
        }
        public ActionResult KategoriGuncelle(kategori k)
        {
            var ktgr = c.kategoris.Find(k.KategoriID);
            ktgr.KategoriAd = k.KategoriAd;
            c.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}