﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using mvconlineotomasyon.Models.sınıflar;
namespace mvconlineticariotomasyonu.Controllers
{
    public class SatisController : Controller
    {
        // GET: Satis
        Contex c = new Contex();
        public ActionResult Index()
        {
            var degerler = c.SatisHarekets.ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult YeniSatis()
        {
            List<SelectListItem> deger1 = (from x in c.Uruns.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.UrunAd,
                                               Value = x.Urunid.ToString()
                                           }).ToList();

            List<SelectListItem> deger2 = (from x in c.Caris.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.CariAd + " " + x.CariSoyad,
                                               Value = x.Cariid.ToString()
                                           }).ToList();

            List<SelectListItem> deger3 = (from x in c.Personels.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.PersonelAd + " " + x.PersonelSoyad,
                                               Value = x.Personelid.ToString()
                                           }).ToList();
           

            ViewBag.dgr1 = deger1;
            ViewBag.dgr2 = deger2;
            ViewBag.dgr3 = deger3;
                return View();
        }
        [HttpPost]
        public ActionResult YeniSatis(SatisHareket s)
        {
            s.Tarih = DateTime.Parse(DateTime.Now.ToShortDateString());
            c.SatisHarekets.Add(s);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult SatisGetir(int id)
        {
            List<SelectListItem> deger1 = (from x in c.Uruns.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.UrunAd,
                                               Value = x.Urunid.ToString()
                                           }).ToList();

            List<SelectListItem> deger2 = (from x in c.Caris.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.CariAd + " " + x.CariSoyad,
                                               Value = x.Cariid.ToString()
                                           }).ToList();

            List<SelectListItem> deger3 = (from x in c.Personels.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.PersonelAd + " " + x.PersonelSoyad,
                                               Value = x.Personelid.ToString()
                                           }).ToList();


            ViewBag.dgr1 = deger1;
            ViewBag.dgr2 = deger2;
            ViewBag.dgr3 = deger3;

            var deger = c.SatisHarekets.Find(id);
            return View("SatisGetir", deger);

        }
        public ActionResult SatisGuncelle(SatisHareket P)
        {
            var deger = c.SatisHarekets.Find(P.Satisid);
            deger.Cariid = P.Cariid;
            deger.Adet = P.Adet;
            deger.Fiyat = P.Fiyat;
            deger.Personelid = P.Personelid;
            deger.Tarih = P.Tarih;
            deger.ToplamTutar = P.ToplamTutar;
            deger.Urunid = P.Urunid;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}