using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using mvconlineotomasyon.Models.sınıflar;
namespace mvconlineotomasyon.Controllers
{
    public class UrunController : Controller
    {
        // GET: Urun
        //contexten nesne türettik c isminde
        Contex c = new Contex();
        public ActionResult Index(string p)
        {
            //durumu true olan ürünleri listeliyoruz, çünkü ilişkili tablolarda silme riskli silince false çevirmiş oluyoruz
            var urunler = from x in c.Uruns select x;
            if (!string.IsNullOrEmpty(p))
            {
                urunler = urunler.Where(y => y.UrunAd.Contains(p));
            }
            //urunleri döndür
            return View(urunler.ToList());
        }
        [HttpGet]
        public ActionResult YeniUrun()
        {
            List<SelectListItem> deger1 = (from x in c.Kategoris.ToList()
                                           select new SelectListItem
                                           {    //dropbanlist
                                               //C# daki combobax
                                               //BİZE GÖRÜNECEK OLAN KISIM
                                               Text = x.KategoriAd,
                                               Value = x.KategoriID.ToString()
                                           }).ToList();//BURDAN GELECEK OLAN DEĞERİN LİSTESİNİ GÖNDER
                                                       //viewBag controller tarafından veri taşımak için
            ViewBag.dgr1 = deger1;

            return View();
        }
        [HttpPost]
        public ActionResult YeniUrun(Urun p)
        {
            c.Uruns.Add(p);
            c.SaveChanges();
            return RedirectToAction("Index");

        }
        public ActionResult UrunSil(int id)
        {
            var deger = c.Uruns.Find(id);
            deger.Durum = false;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult UrunGetir(int id)
        {
            List<SelectListItem> deger1 = (from x in c.Kategoris.ToList()
                                           select new SelectListItem
                                           {    //dropbanlist
                                               //C# daki combobax
                                               //BİZE GÖRÜNECEK OLAN KISIM
                                               Text = x.KategoriAd,
                                               Value = x.KategoriID.ToString()
                                           }).ToList();//BURDAN GELECEK OLAN DEĞERİN LİSTESİNİ GÖNDER
                                                       //viewBag controller tarafından veri taşımak için
            ViewBag.dgr1 = deger1;

            var urundeger = c.Uruns.Find(id);
            return View("UrunGetir", urundeger);
        }
        public ActionResult UrunGuncelle(Urun p)
        {
            var urn = c.Uruns.Find(p.Urunid);
            urn.AlisFiyat = p.AlisFiyat;
            urn.Durum = p.Durum;
            urn.Kategoriid = p.Kategoriid;
            urn.Marka = p.Marka;
            urn.SatisFiyat = p.SatisFiyat;
            urn.Stok = p.Stok;
            urn.UrunAd = p.UrunAd;
            urn.UrunGorsel = p.UrunGorsel;
            c.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}