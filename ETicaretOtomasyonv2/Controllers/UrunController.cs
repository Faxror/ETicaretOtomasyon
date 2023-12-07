
using ETicaretOtomasyonv2.Models.Siniflar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ETicaretOtomasyonv2.Controllers
{
    public class UrunController : Controller
    {
        // GET: Urun

        Context c = new Context();
        public ActionResult Index()
        {
            var degersiz = c.Urunlers.Where(z => z.Durum == true).ToList();
            return View(degersiz);
        }



        [HttpGet]
        public ActionResult UrunAdd()
        {
            List<SelectListItem> urunlers = (from x in c.Kategoris.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = x.KategoriAd,
                                                 Value = x.KategoriID.ToString()
                                             }).ToList();
            ViewBag.dgr1 = urunlers;
            return View();
        }

        [HttpPost]
        public ActionResult UrunAdd(Urunler u)
        {
            c.Urunlers.Add(u);
            c.SaveChanges();
            return RedirectToAction("Index");
        }


        public ActionResult UrunDelete(int id)
        {
            var urun = c.Urunlers.Find(id);
            urun.Durum = false;
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult UrunGetir(int id)
        {
            List<SelectListItem> urunle2rs = (from x in c.Kategoris.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = x.KategoriAd,
                                                 Value = x.KategoriID.ToString()
                                             }).ToList();
            ViewBag.dgr2 = urunle2rs;
            var ur2un = c.Urunlers.Find(id);
            return View("UrunGetir", ur2un);
        }

        public ActionResult UrunGuncelle(Urunler p)
        {
            var ur = c.Urunlers.Find(p.UrunID);
            ur.Fiyat = p.Fiyat;
            ur.Durum = p.Durum;
            ur.Kategoriid = p.Kategoriid;
            ur.Marka = p.Marka;
            ur.StokSayısı = p.StokSayısı;
            ur.UrunGorsel = p.UrunGorsel;
            ur.UrunAd = p.UrunAd;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}