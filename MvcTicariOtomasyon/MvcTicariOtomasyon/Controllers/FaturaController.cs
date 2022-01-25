using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcTicariOtomasyon.Models.siniflar;
namespace MvcTicariOtomasyon.Controllers
{
    public class FaturaController : Controller
    {
        // GET: Fatura
        context c = new context();
        public ActionResult Index()
        {
            var liste = c.faturalars.ToList();
            return View(liste);
        }
        [HttpGet]
        public ActionResult FaturaEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult FaturaEkle(faturalar f)
        {
            c.faturalars.Add(f);
            c.SaveChanges();
            return RedirectToAction("Index");
           
        }
        public ActionResult FaturaGetir(int id)
        {
            var fatura = c.faturalars.Find(id);
            return View("FaturaGetir", fatura);//geriye faturagetir Döndürülecek,fatura adlı degişkenden gelecek olan degerle  beraber döndürecek
        }
        public ActionResult FaturaGuncelle(faturalar f)
        {
            var fatura = c.faturalars.Find(f.Faturaid);
            fatura.FaturaSeriNo = f.FaturaSeriNo;
            fatura.FaturaSiraNo = f.FaturaSiraNo;
            fatura.Saat = f.Saat;
            fatura.Tarih = f.Tarih;
            fatura.TeslimAlan = f.TeslimAlan;
            fatura.TeslimEden = f.TeslimEden;
            fatura.VergiDairesi = f.VergiDairesi;
            fatura.Toplam = f.Toplam;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult FaturaDetay(int id)
        {
            var degerler = c.faturaKalems.Where(x => x.Faturaid == id).ToList();
            
            return View(degerler);
        }
        [HttpGet]
        public ActionResult YeniKalem()
        {
            return View();   
        }
        public ActionResult YeniKalem(faturaKalem p)
        {
            c.faturaKalems.Add(p);
            c.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}