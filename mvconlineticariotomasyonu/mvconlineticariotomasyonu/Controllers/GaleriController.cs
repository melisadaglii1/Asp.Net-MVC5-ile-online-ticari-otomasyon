using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using mvconlineotomasyon.Models.sınıflar;
namespace mvconlineotomasyon.Controllers


{
    public class GaleriController : Controller
    {
        // GET: Galeri
        Contex c = new Contex();
        public ActionResult Index()
        {
            var degerler = c.Uruns.ToList();
            return View(degerler);
        }
    }
}