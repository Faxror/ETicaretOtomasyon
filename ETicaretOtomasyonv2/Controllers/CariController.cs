using ETicaretOtomasyonv2.Models.Siniflar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ETicaretOtomasyonv2.Controllers
{
    public class CariController : Controller
    {
        // GET: Cari

        Context c = new Context();
        public ActionResult Index()
        {
            var degerr = c.Carilers.Where(x => x.Durum == true).ToList();
            return View(degerr);
        }



        [HttpGet]
        public ActionResult CariEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CariEkle(Cariler ca)
        {
            c.Carilers.Add(ca);
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult CariGetir(int id)
        {
            var carie = c.Carilers.Find(id);

            return View("CariGetir", carie);
        }

        public ActionResult CariGuncelle(Cariler k)
        {
            var guncelle = c.Carilers.Find(k.Cariid);
            guncelle.CariAd = k.CariAd;
            guncelle.CariSoyad = k.CariSoyad;
            guncelle.CariSehir = k.CariSehir;
            guncelle.CariMail = k.CariMail;
            guncelle.CariUlke = k.CariUlke;
            guncelle.Durum = k.Durum;
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult CariDelete(int id)
        {
            var caridelete = c.Carilers.Find(id);
            caridelete.Durum = false;
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult  MusteriSatis(int id)
        {
            var musteri = c.SatisHarekets.Where(x => x.CariID == id).ToList();
            var de = c.Carilers.Where(x => x.Cariid == id).Select(y => y.CariAd ).FirstOrDefault();
            var ni = c.Carilers.Where(x => x.Cariid == id).Select(y => y.CariSoyad).FirstOrDefault();
            ViewBag.carid = de;
            ViewBag.carid2 = ni;
       
            return View(musteri);
        }
    }
}