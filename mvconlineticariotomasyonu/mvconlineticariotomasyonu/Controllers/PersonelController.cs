using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using mvconlineotomasyon.Models.sınıflar;

namespace mvconlineticariotomasyonu.Controllers
{
    public class PersonelController : Controller
    {
        // GET: Personel
        Contex c = new Contex();
        public ActionResult Index()
        {
            var degerler = c.Personels.ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult PersonelEkle()
        {
            List<SelectListItem> deger1 = (from x in c.Departmans.ToList()
                                           select new SelectListItem
                                           {    //dropbanlist
                                               //C# daki combobax
                                               //BİZE GÖRÜNECEK OLAN KISIM
                                               Text = x.DepartmanAd,
                                               Value = x.Departmanid.ToString()
                                           }).ToList();//BURDAN GELECEK OLAN DEĞERİN LİSTESİNİ GÖNDER
                                                       //viewBag controller tarafından veri taşımak için
            ViewBag.dgr1 = deger1;

            return View();
        }
        [HttpPost]
        public ActionResult PersonelEkle(Personel p)
        {
            c.Personels.Add(p);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult PersonelGetir(int id)
        {
            List<SelectListItem> deger1 = (from x in c.Departmans.ToList()
                                           select new SelectListItem
                                           {    //dropbanlist
                                               //C# daki combobax
                                               //BİZE GÖRÜNECEK OLAN KISIM
                                               Text = x.DepartmanAd,
                                               Value = x.Departmanid.ToString()
                                           }).ToList();//BURDAN GELECEK OLAN DEĞERİN LİSTESİNİ GÖNDER
                                                       //viewBag controller tarafından veri taşımak için
            ViewBag.dgr1 = deger1;

            var prs = c.Personels.Find(id);
            return View("PersonelGetir", prs);
        }
        public ActionResult PersonelGuncelle(Personel p)
        {
            var prsn = c.Personels.Find(p.Personelid);
            prsn.PersonelAd = p.PersonelAd;
            prsn.PersonelSoyad = p.PersonelSoyad;
            prsn.PersonelGorsel = p.PersonelGorsel;
            prsn.Departmanid = p.Departmanid;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}