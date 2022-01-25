using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcTicariOtomasyon.Models.siniflar;
namespace MvcTicariOtomasyon.Controllers
{
    public class GaleriController : Controller
    {
        // GET: Galeri
        context c = new context();
        public ActionResult Index()
        {
            var degerler = c.uruns.ToList();
            return View(degerler);
        }
    }
}