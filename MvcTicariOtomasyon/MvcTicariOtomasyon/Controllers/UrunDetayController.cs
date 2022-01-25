using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcTicariOtomasyon.Models.siniflar;


namespace MvcTicariOtomasyon.Controllers
{
    public class UrunDetayController : Controller
    {
        // GET: UrunDetay
        context c = new context();
        public ActionResult Index()
        {
            Class1 cs = new Class1();
            //var degerler = c.uruns.Where(x => x.Urunid == 1).ToList();
            cs.Deger1 = c.uruns.Where(x => x.Urunid == 1).ToList();
            cs.Deger2 = c.Detays.Where(y => y.KategoriID == 1).ToList();
            return View(cs);
        }
    }
}