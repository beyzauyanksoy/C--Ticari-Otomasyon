using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcTicariOtomasyon.Models.siniflar;

namespace MvcTicariOtomasyon.Controllers
{
    public class YapilacakController : Controller
    {
        // GET: Yapilacak
        context c = new context();
        public ActionResult Index()
        {
            var deger1 = c.carilers.Count().ToString();
            ViewBag.d1 = deger1;

            var deger2 = c.uruns.Count().ToString();
            ViewBag.d2 = deger2;

            var deger3 = c.kategoris.Count().ToString();
            ViewBag.d3 = deger3;

            var deger4 = (from x in c.carilers select x.CariSehir).Distinct().Count().ToString();
            ViewBag.d4 = deger4;

            var yapilacaklar = c.Yapilacaks.ToList();
            return View(yapilacaklar);
        }
    }
}