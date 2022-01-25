using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcTicariOtomasyon.Models.siniflar;

namespace MvcTicariOtomasyon.Controllers
{
    public class DepartmanController : Controller
    {
        // GET: Departman

        context c = new context();

        public ActionResult Index()
        {
            var degerler = c.departmans.Where(x=>x.Durum==true).ToList();

            return View(degerler);
        }
        [HttpGet]
        public ActionResult DepartmanEkle()
        {
            return View();

        }



        [HttpPost]
        public ActionResult DepartmanEkle(departman d)
        {
            c.departmans.Add(d);
            c.SaveChanges();
           return RedirectToAction("Index");
        }
        public ActionResult DepartmanSil(int id)
        {
            var dep = c.departmans.Find(id);
            dep.Durum = false;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DepartmanGetir(int id)
        {
            var dpt = c.departmans.Find(id);
            return View("DepartmanGetir", dpt);
        }
        public ActionResult DepartmanGuncelle(departman p)
        {
            var dept = c.departmans.Find(p.Departmanid);
            dept.DepartmanAd = p.DepartmanAd;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DepartmanDetay(int id)
        {
            var degerler = c.personels.Where(x => x.Departmanid == id).ToList();
            var dpt = c.departmans.Where(x => x.Departmanid == id).Select(y => y.DepartmanAd).FirstOrDefault();
            ViewBag.d = dpt;
            return View(degerler);
        }
        public ActionResult DepartmanPersonelSatis(int id)
        {
           
            var degerler = c.satisHarekets.Where(x => x.Personelid == id).ToList();
            var per = c.personels.Where(x => x.Personelid == id).Select(y => y.PersonelAd+" " + y.PersonelSoyad).FirstOrDefault();
            ViewBag.dpers = per;
            return View(degerler);
        }
        
        
    }
}