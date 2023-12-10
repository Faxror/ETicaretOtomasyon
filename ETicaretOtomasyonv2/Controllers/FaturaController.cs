using ETicaretOtomasyonv2.Models.Siniflar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ETicaretOtomasyonv2.Controllers
{
    public class FaturaController : Controller
    {
        // GET: Fatura

        Context c = new Context();
        public ActionResult Index()
        {
            var listele = c.Faturalars.ToList();
            return View(listele);
        }

        [HttpGet]
        public ActionResult FaturaEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult FaturaEkle(Faturalar d)
        {
            c.Faturalars.Add(d);
            c.SaveChanges();
            return RedirectToAction("Index");
        }



        public ActionResult FaturaGetir(int id)
        {
            var dgr = c.Faturalars.Find(id);

            return View("FaturaGetir", dgr);
        }

        public ActionResult FaturaGuncelle(Faturalar k)
        {
            var guncelle = c.Faturalars.Find(k.FaturaID);
            guncelle.FaturaSerino = k.FaturaSerino;
            guncelle.FaturaSırano = k.FaturaSırano;
            guncelle.Saat = k.Saat;
            guncelle.Tarihi = k.Tarihi;
            guncelle.TeslimAlan = k.TeslimAlan;
            guncelle.TeslimEden = k.TeslimEden;
            c.SaveChanges();
            return RedirectToAction("Index");
        }


        public ActionResult FaturaDetay(int id)
        {
            var dep = c.FaturaKalems.Where(x => x.FaturaKalemID == id).ToList();

            return View(dep);
        }

        [HttpGet]
        public ActionResult KalemGiris()
        {
            return View();
        }

        [HttpPost]
        public ActionResult KalemGiris(FaturaKalem d)
        {
            c.FaturaKalems.Add(d);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}